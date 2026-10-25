using Haveno.Api.Services;
using Haveno.Api.Singletons;
using Haveno.Processes;
using Haveno.Tests.Wallet;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Haveno.Tests;

public partial class MoneroDaemon : IAsyncDisposable
{
    private readonly SemaphoreSlim _semaphoreSlim = new(1, 1);
    private readonly SemaphoreSlim _miningSemaphoreSlim = new(1, 1);

    private CancellationTokenSource? _cancellationTokenSource;
    private Task? Task {  get; set; }
    private ManagedProcess? Process { get; set; }
    private TaskCompletionSource<bool>? _monerodReadyTCS;
    private TaskCompletionSource<bool>? _miningTCS;
    private volatile bool _isMining;

    public string? P2pBindIp { get; set; }
    public string? RpcBindIp { get; set; } 
    public int P2pBindPort { get; set; }
    public int RpcBindPort { get; set; }

    public int Difficulty { get; set; } = 50;
    public int LogLevel { get; set; } = 0;
    public List<string> ExclusiveNodes { get; set; } = [];

    public string DataDir { get; }
    public string ExecutablePath { get; }

    public int CurrentHeight { get; private set; }

    public event Action<int>? BlockFound;

    public MoneroDaemon(string executablePath, string dataDir)
    {
        ExecutablePath = executablePath;
        DataDir = dataDir;
    }

    [GeneratedRegex(@"at height ([0-9]+) for", RegexOptions.IgnoreCase, "en-US")]
    private static partial Regex BlockFoundRegex();

    public async Task StopAsync()
    {
        if (!_semaphoreSlim.Wait(0))
            return;

        try
        {
            if (Process is null || Process.HasExited)
                throw new Exception();

            if (Task is null || _cancellationTokenSource is null)
                return;

            _cancellationTokenSource.Cancel();
            await Task;

            Task = null;
            _cancellationTokenSource.Dispose();
            _cancellationTokenSource = null;
            _monerodReadyTCS = null;
        }
        finally
        {
            _semaphoreSlim.Release();
        }
    }

    public async Task StartAsync(CancellationToken? cancellationToken = default, bool logToConsole = false)
    {
        if (!_semaphoreSlim.Wait(0))
            return;

        try
        {
            CancellationTokenSource linkedCancellationTokenSource;
            _cancellationTokenSource = new();
            _monerodReadyTCS = new();

            var regex = BlockFoundRegex();

            if (cancellationToken is not null)
            {
                linkedCancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken.Value, _cancellationTokenSource.Token);
            }
            else
            {
                linkedCancellationTokenSource = _cancellationTokenSource;
            }

            Task = Task.Factory.StartNew((obj) =>
            {
                ProcessStartInfo processStartInfo = new(ExecutablePath)
                {
                    WorkingDirectory = DataDir,
                    RedirectStandardOutput = true,
                    RedirectStandardInput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    ArgumentList =
                    {
                        $"--p2p-bind-port={P2pBindPort}",
                        $"--rpc-bind-port={RpcBindPort}",
                        $"--data-dir={DataDir}",
                        $"--fixed-difficulty={Difficulty}",
                        $"--log-level={LogLevel}",
                        $"--testnet",
                        $"--no-igd",
                        $"--hide-my-port",
                        $"--no-zmq",
                        $"--non-interactive",
                        $"--disable-rpc-ban",
                        $"--rpc-max-connections=1000",
                        $"--max-connections-per-ip=10",
                        $"--rpc-access-control-origins=http://localhost:8080",
                        $"--rpc-max-connections-per-private-ip=1000"
                    }
                };

                if (!string.IsNullOrEmpty(P2pBindIp))
                {
                    processStartInfo.ArgumentList.Add($"--p2p-bind-ip={P2pBindIp}");
                }

                if (!string.IsNullOrEmpty(RpcBindIp))
                {
                    processStartInfo.ArgumentList.Add($"--rpc-bind-ip={RpcBindIp}");
                }

                foreach (var node in ExclusiveNodes.Select(x => $"--add-exclusive-node={x}"))
                {
                    processStartInfo.ArgumentList.Add(node);
                }

                Process = ManagedProcess.Start(processStartInfo);

                string? line;
                while (!linkedCancellationTokenSource.IsCancellationRequested && (line = Process.StandardOutput.ReadLine()) is not null)
                {
                    if (logToConsole)
                        Debug.WriteLine(line);

                    // "Synced n/n"
                    if ((line.Contains("You are now synchronized with the network") || line.Contains("Synced ")) && !_monerodReadyTCS.Task.IsCompleted)
                    {
                        _monerodReadyTCS.SetResult(true);
                    }
                    else if (line.Contains("Mining has started"))
                    {
                        _miningTCS?.SetResult(true);
                    }
                    else if (line.Contains("Mining has been stopped"))
                    {
                        _miningTCS?.SetResult(false);
                    }
                    else if (regex.Match(line) is { Success: true } match && int.TryParse(match.Groups[1].Value, out int number))
                    {
                        CurrentHeight = number;
                        BlockFound?.Invoke(number);
                    }
                }

                Process.StandardInput.WriteLine("stop_daemon");
                //while (!linkedCancellationTokenSource.IsCancellationRequested && !Process.HasExited && (line = Process.StandardOutput.ReadLine()) is not null)
                //while ((line = Process.StandardOutput.ReadLine()) is not null)
                //{
                //    if (logToConsole)
                //        Debug.WriteLine(line);

                //    if (line.Contains("p2p net loop stopped"))
                //        break;
                //}

                Process.Kill();
                Process.WaitForExit();
                Process.Dispose();

                Process = null;
            },
            TaskCreationOptions.LongRunning);

            await _monerodReadyTCS.Task;
        }
        finally
        {
            _semaphoreSlim.Release();
        }
    }

    // Should throw if non interactive
    public async Task StartMiningAsync(string address)
    {
        if (!_miningSemaphoreSlim.Wait(0))
            return;

        try
        {
            if (Process is null || Task is null || _monerodReadyTCS is null || !_monerodReadyTCS.Task.IsCompleted || _isMining)
                return;

            _miningTCS = new();
            Process.StandardInput.WriteLine($"start_mining {address} 1");

            _isMining = await _miningTCS.Task;
            _miningTCS = null;
        }
        finally
        {
            _miningSemaphoreSlim.Release();
        }
    }

    public async Task StopMining()
    {
        if (!_miningSemaphoreSlim.Wait(0))
            return;

        try
        {
            if (Process is null || Task is null || _monerodReadyTCS is null || !_monerodReadyTCS.Task.IsCompleted || !_isMining)
                return;

            _miningTCS = new();

            Process.StandardInput.WriteLine("stop_mining");

            _isMining = await _miningTCS.Task;
            _miningTCS = null;
        }
        finally
        {
            _miningSemaphoreSlim.Release();
        }
    }

    public async ValueTask DisposeAsync()
    {
        await StopAsync();
        GC.SuppressFinalize(this);
    }
}

public class SetupFixture : IAsyncLifetime
{
    private readonly AppSettings _appSettings;

    private readonly string _user_1 = "user_1";
    private readonly string _user_2 = "user_2";
    private readonly string _arbitrator = "arbitrator";
    private readonly string _basePath;
    private readonly string _dataPath;
    private readonly string _havenoPath;
    private readonly string _moneroPath;

    public ManagedProcess? WalletRpc { get; private set; }
    public Dictionary<string, HavenoDaemon> HavenoDaemons { get; } = [];
    public Dictionary<string, MoneroDaemon> MoneroDaemons { get; } = [];
    public IServiceProvider ServiceProvider { get; }
    public static string AccountPassword { get; set; } = "test123456";

    public SetupFixture()
    {
        _basePath = Path.Combine(
            Path.GetTempPath(), 
            Guid.NewGuid().ToString());

        _dataPath = Path.Combine(_basePath, "data");
        _havenoPath = Path.Combine(_dataPath, "haveno");
        _moneroPath = Path.Combine(_dataPath, "monero");

        Directory.CreateDirectory(_havenoPath);
        Directory.CreateDirectory(_moneroPath);

        var config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json").Build();

        var section = config.GetSection("AppSettings");
        _appSettings = section.Get<AppSettings>() ?? throw new Exception("Could not read AppSettings.");

        var services = new ServiceCollection();
        // Singleton?
        services.AddScoped<MoneroWalletService>();

        services.AddKeyedSingleton<GrpcChannelSingleton>(_user_1, (serviceProvider, a) =>
        {
            var grpcChannelSingleton = new GrpcChannelSingleton();
            grpcChannelSingleton.CreateChannel("http://127.0.0.1:9999", "apitest");
            return grpcChannelSingleton;
        });

        services.AddKeyedSingleton<GrpcChannelSingleton>(_user_2, (serviceProvider, a) =>
        {
            var grpcChannelSingleton = new GrpcChannelSingleton();
            grpcChannelSingleton.CreateChannel("http://127.0.0.1:9998", "apitest");
            return grpcChannelSingleton;
        });

        services.AddKeyedSingleton<GrpcChannelSingleton>(_arbitrator, (serviceProvider, a) =>
        {
            var grpcChannelSingleton = new GrpcChannelSingleton();
            grpcChannelSingleton.CreateChannel("http://127.0.0.1:9997", "apitest");
            return grpcChannelSingleton;
        });

        services.AddMemoryCache();

        services.AddKeyedSingleton<INotificationsSingleton, NotificationsSingleton>(_user_1, (serviceProvider, key) => new NotificationsSingleton(serviceProvider.GetRequiredKeyedService<GrpcChannelSingleton>(key)));
        services.AddKeyedScoped<IVersionService, VersionService>(_user_1, (serviceProvider, key) => new VersionService(serviceProvider.GetRequiredKeyedService<GrpcChannelSingleton>(key)));

        services.AddKeyedScoped<IDisputeAgentService, DisputeAgentService>(_arbitrator, (serviceProvider, key) => new DisputeAgentService(serviceProvider.GetRequiredKeyedService<GrpcChannelSingleton>(key)));
        services.AddKeyedScoped<IAccountService, AccountService>(_arbitrator, (serviceProvider, key) => new AccountService(serviceProvider.GetRequiredKeyedService<GrpcChannelSingleton>(key)));
        services.AddKeyedScoped<IDisputeService, DisputeService>(_arbitrator, (serviceProvider, key) => new DisputeService(serviceProvider.GetRequiredKeyedService<GrpcChannelSingleton>(key)));

        services.AddKeyedScoped<IAccountService, AccountService>(_user_2, (serviceProvider, key) => new AccountService(serviceProvider.GetRequiredKeyedService<GrpcChannelSingleton>(key)));
        services.AddKeyedScoped<IWalletService, WalletService>(_user_2, (serviceProvider, key) => new WalletService(serviceProvider.GetRequiredKeyedService<GrpcChannelSingleton>(key)));
        services.AddKeyedScoped<IOffersService, OffersService>(_user_2, (serviceProvider, key) => new OffersService(serviceProvider.GetRequiredKeyedService<GrpcChannelSingleton>(key)));
        services.AddKeyedScoped<ITradeService, TradeService>(_user_2, (serviceProvider, key) => new TradeService(serviceProvider.GetRequiredKeyedService<GrpcChannelSingleton>(key)));
        services.AddKeyedScoped<IPaymentAccountService, PaymentAccountService>(_user_2, (serviceProvider, key) => new PaymentAccountService(serviceProvider.GetRequiredKeyedService<GrpcChannelSingleton>(key), serviceProvider.GetRequiredService<IMemoryCache>()));
        services.AddKeyedScoped<IDisputeService, DisputeService>(_user_2, (serviceProvider, key) => new DisputeService(serviceProvider.GetRequiredKeyedService<GrpcChannelSingleton>(key)));

        services.AddKeyedScoped<IAccountService, AccountService>(_user_1, (serviceProvider, key) => new AccountService(serviceProvider.GetRequiredKeyedService<GrpcChannelSingleton>(key)));
        services.AddKeyedScoped<IWalletService, WalletService>(_user_1, (serviceProvider, key) => new WalletService(serviceProvider.GetRequiredKeyedService<GrpcChannelSingleton>(key)));
        services.AddKeyedScoped<IOffersService, OffersService>(_user_1, (serviceProvider, key) => new OffersService(serviceProvider.GetRequiredKeyedService<GrpcChannelSingleton>(key)));
        services.AddKeyedScoped<ITradeService, TradeService>(_user_1, (serviceProvider, key) => new TradeService(serviceProvider.GetRequiredKeyedService<GrpcChannelSingleton>(key)));
        services.AddKeyedScoped<IPaymentAccountService, PaymentAccountService>(_user_1, (serviceProvider, key) => new PaymentAccountService(serviceProvider.GetRequiredKeyedService<GrpcChannelSingleton>(key), serviceProvider.GetRequiredService<IMemoryCache>()));
        services.AddKeyedScoped<IDisputeService, DisputeService>(_user_1, (serviceProvider, key) => new DisputeService(serviceProvider.GetRequiredKeyedService<GrpcChannelSingleton>(key)));

        //
        services.AddKeyedScoped<ITradeStatisticsService, TradeStatisticsService>(_user_1, (serviceProvider, key) => new TradeStatisticsService(serviceProvider.GetRequiredKeyedService<GrpcChannelSingleton>(key)));

        ServiceProvider = services.BuildServiceProvider();
    }

    private static async Task WaitAppInitializedAsync(IAccountService accountService)
    {
        for (int i = 0; i < 600; i++)
        {
            try
            {
                if (await accountService.IsAppInitializedAsync())
                    return;
            }
            catch
            {

            }

            await Task.Delay(1_000);
        }

        throw new Exception("IsAppInitialized timed out.");
    }

    private async Task SetupHavenoUser(string user)
    {
        var accountService = ServiceProvider.GetRequiredKeyedService<IAccountService>(user);

        await accountService.CreateAccountAsync(AccountPassword);
        await accountService.OpenAccountAsync(AccountPassword);

        await WaitAppInitializedAsync(accountService);
    }

    private async Task SetupFundingWallet()
    {
        TaskCompletionSource walletRpcTCS = new();

        _ = Task.Factory.StartNew(() =>
        {
            ProcessStartInfo processStartInfo = new(_appSettings.MoneroRpcExecutablePath)
            {
                WorkingDirectory = _moneroPath,
                RedirectStandardOutput = true,
                RedirectStandardInput = true,
                //RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                ArgumentList =
                {
                    $"--testnet",
                    $"--daemon-address=http://localhost:28081",
                    $"--rpc-bind-port=28084",
                    $"--wallet-dir={_moneroPath}",
                    $"--disable-rpc-login",
                    $"--trusted-daemon",
                    $"--rpc-access-control-origins=http://localhost:8080",
                    $"--no-dns",
                    $"--log-level=4"
                }
            };

            WalletRpc = ManagedProcess.Start(processStartInfo);

            string? line;
            while ((line = WalletRpc.StandardOutput.ReadLine()) is not null)
            {
                if (line.Contains("Automated wallet block refresh took") && !walletRpcTCS.Task.IsCompleted)
                {
                    walletRpcTCS.SetResult();
                }
            }
        }, TaskCreationOptions.LongRunning);

        await walletRpcTCS.Task;

        var moneroWalletService = ServiceProvider.GetRequiredService<MoneroWalletService>();

        try
        {
            await moneroWalletService.OpenWalletAsync("haveno-funding");
        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("file not found"))
            {
                await moneroWalletService.RestoreDeterministicWallet("haveno-funding", "total dusted either sickness ought taboo ignore buzzer agreed guru claim cajun hefty problems waking navy emails uttered koala fungal fidget summon pebbles pool koala");
            }
        }

        await moneroWalletService.RefreshWalletAsync();

        TaskCompletionSource initialBlocksMined = new();
        MoneroDaemons.TryGetValue("monerod_2", out var monerod);
        monerod!.BlockFound += blockNumber =>
        {
            Debug.WriteLine($"New block found at height: {blockNumber}");

            if (blockNumber >= 150 && !initialBlocksMined.Task.IsCompleted)
            {
                initialBlocksMined.SetResult();
            }
        };

        await moneroWalletService.StartMiningAsync(2, false, true);

        await initialBlocksMined.Task;

        await moneroWalletService.StopMiningAsync();
    }

    public async Task InitializeAsync()
    {
        await StartLocalNetwork();

        await Task.WhenAll(
            SetupHavenoUser(_arbitrator),
            SetupHavenoUser(_user_1),
            SetupHavenoUser(_user_2),
            SetupFundingWallet());


        var disputeAgentService = ServiceProvider.GetRequiredKeyedService<IDisputeAgentService>(_arbitrator);
        await disputeAgentService.RegisterDisputeAgentAsync(
            "arbitrator", 
            "6ac43ea1df2a290c1c8391736aa42e4339c5cb4f110ff0257a13b63211977b7a");
    }

    public async Task DisposeAsync()
    {
        foreach (var havenoDaemon in HavenoDaemons)
        {
            try
            {
                havenoDaemon.Value.Dispose();
            }
            catch
            {

            }
        }

        foreach (var moneroDaemon in MoneroDaemons)
        {
            await moneroDaemon.Value.StopAsync();
        }

        WalletRpc?.Dispose();
        //await WalletRpc?.WaitForExitAsync();

        Directory.Delete(_basePath, true);
    }

    private async Task StartLocalNetwork()
    {
        Directory.CreateDirectory(Path.Combine(_moneroPath, "node1"));
        Directory.CreateDirectory(Path.Combine(_moneroPath, "node2"));

        var monerod_1 = new MoneroDaemon(_appSettings.MoneroDaemonExecutablePath, Path.Combine(_moneroPath, "node1"))
        {
            ExclusiveNodes = [ "127.0.0.1:28080" ],
            P2pBindIp = "127.0.0.1",
            P2pBindPort = 48080,
            RpcBindPort = 48081,
            LogLevel = 2
        };

        var monerod_1_Task = monerod_1.StartAsync(logToConsole: true);

        var monerod_2 = new MoneroDaemon(_appSettings.MoneroDaemonExecutablePath, Path.Combine(_moneroPath, "node2")) 
        {
            ExclusiveNodes = [ "127.0.0.1:48080" ],
            P2pBindIp = "127.0.0.1",
            RpcBindIp = "127.0.0.1",
            P2pBindPort = 28080,
            RpcBindPort = 28081,
            LogLevel = 2
        };

        var monerod_2_Task = monerod_2.StartAsync(logToConsole: true);

        await Task.WhenAll(monerod_1_Task, monerod_2_Task);

        MoneroDaemons.Add("monerod_1", monerod_1);
        MoneroDaemons.Add("monerod_2", monerod_2);

        //monerod_2.BlockFound += blockNumber => Debug.WriteLine($"New block found at height: {blockNumber}");
        //await monerod_2.StartMiningAsync("9sRemKQY2VxBf6xdiPNe4oh6Sc3Zd1pr6Ygidkr6g6tbdq55kgoJ2uiWK9KoZQKQPUZ9LsWkXpV4FTn6YLCDdUsy3ExZ8ch");

        //do
        //{
        //    await Task.Delay(100);
        //}
        //while (monerod_2.CurrentHeight < 150);

        //await monerod_2.StopMining();

        //await monerod_2.StopAsync();
        //await monerod_1.StopAsync();

        //monerod_2.Difficulty = 500;
        //monerod_1.Difficulty = 500;

        //monerod_2_Task = monerod_2.StartAsync(logToConsole: false);
        //monerod_1_Task = monerod_1.StartAsync(logToConsole: false);

        //await Task.WhenAll(monerod_1_Task, monerod_2_Task);

        //await monerod_2.StartMiningAsync("9tsUiG9bwcU7oTbAdBwBk2PzxFtysge5qcEsHEpetmEKgerHQa1fDqH7a4FiquZmms7yM22jdifVAD7jAb2e63GSJMuhY75");

        HavenoDaemon havenoSeed_1 = new(
            _appSettings.HavenoSeedExecutablePath,
            new HavenoDaemonArguments
            {
                NodePort = 2002,
                UseDevPrivilegeKeys = true,
                UseLocalhostForP2P = true,
                NetworkType = HavenoNetworkType.XMR_LOCAL,
                XmrNode = "http://localhost:28081",
                AppName = "haveno-XMR_LOCAL_Seed_2002",
                UserDataDir = _havenoPath
            }, true);

        HavenoDaemons.Add("havenoSeed_1", havenoSeed_1);

        await havenoSeed_1.StartAsync();

        HavenoDaemon havenoSeed_2 = new(
            _appSettings.HavenoSeedExecutablePath,
            new HavenoDaemonArguments
            {
                NodePort = 2003,
                UseDevPrivilegeKeys = true,
                UseLocalhostForP2P = true,
                NetworkType = HavenoNetworkType.XMR_LOCAL,
                XmrNode = "http://localhost:28081",
                AppName = "haveno-XMR_LOCAL_Seed_2003",
                UserDataDir = _havenoPath
            }, true);

        HavenoDaemons.Add("havenoSeed_2", havenoSeed_2);

        await havenoSeed_2.StartAsync();

        HavenoDaemon havenoDaemon_user_1 = new(
            _appSettings.HavenoDaemonExecutablePath,
            new HavenoDaemonArguments
            {
                ApiPort = 9999,
                NodePort = 4444,
                AppName = "haveno-XMR_LOCAL_user1",
                PasswordRequired = true,
                WalletRpcBindPort = 41_200,
                LogLevel = "INFO",
                UseDevPrivilegeKeys = true,
                UseLocalhostForP2P = true,
                NetworkType = HavenoNetworkType.XMR_LOCAL,
                UserDataDir = _havenoPath,
                ApiPassword = "apitest"
            });

        HavenoDaemons.Add("havenoDaemon_user_1", havenoDaemon_user_1);

        var user_1_DaemonTask = havenoDaemon_user_1.StartAsync();

        HavenoDaemon havenoDaemon_user_2 = new(
            _appSettings.HavenoDaemonExecutablePath,
            new HavenoDaemonArguments
            {
                ApiPort = 9998,
                NodePort = 5555,
                AppName = "haveno-XMR_LOCAL_user2",
                PasswordRequired = true,
                WalletRpcBindPort = 41_201,
                LogLevel = "INFO",
                UseDevPrivilegeKeys = true,
                UseLocalhostForP2P = true,
                NetworkType = HavenoNetworkType.XMR_LOCAL,
                UserDataDir = _havenoPath,
                ApiPassword = "apitest"
            });

        HavenoDaemons.Add("havenoDaemon_user_2", havenoDaemon_user_2);

        var user_2_DaemonTask = havenoDaemon_user_2.StartAsync();

        HavenoDaemon havenoDaemon_arbitrator = new(
            _appSettings.HavenoDaemonExecutablePath,
            new HavenoDaemonArguments
            {
                ApiPort = 9997,
                NodePort = 6666,
                AppName = "haveno-XMR_LOCAL_arbitrator",
                PasswordRequired = true,
                WalletRpcBindPort = 41_202,
                LogLevel = "INFO",
                UseDevPrivilegeKeys = true,
                UseLocalhostForP2P = true,
                NetworkType = HavenoNetworkType.XMR_LOCAL,
                UserDataDir = _havenoPath,
                ApiPassword = "apitest"
            });

        HavenoDaemons.Add("havenoDaemon_arbitrator", havenoDaemon_arbitrator);

        var arbitratorDaemonTask = havenoDaemon_arbitrator.StartAsync();

        await Task.WhenAll(user_1_DaemonTask, user_2_DaemonTask, arbitratorDaemonTask);
    }
}

[CollectionDefinition(nameof(SetupCollection))]
public class SetupCollection : ICollectionFixture<SetupFixture>
{
    
}
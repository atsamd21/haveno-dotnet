using Haveno.Exceptions;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Haveno.Processes;

public enum HavenoNetworkType
{
    XMR_MAINNET,
    XMR_LOCAL,
    XMR_STAGENET
}

public class HavenoDaemonArguments
{
    public int? ApiPort { get; set; }
    public int? NodePort { get; set; }
    public string? AppName { get; set; }
    public string? UserDataDir { get; set; }
    public string? ApiPassword { get; set; }
    public string? LogLevel { get; set; }
    public bool? PasswordRequired { get; set; }
    public bool? UseDevPrivilegeKeys { get; set; }
    public bool? UseLocalhostForP2P { get; set; }
    public HavenoNetworkType? NetworkType { get; set; }
    public bool? DisableRateLimits { get; set; }
    public bool? UseNativeXmrWallet { get; set; }
    public string? XmrNode { get; set; }
    public int? WalletRpcBindPort { get; set; }
    public string? AppDataDir { get; set; }
}

public class HavenoDaemon : IDisposable
{
    private readonly string _havenoDaemonPath;
    private readonly bool _isSeedNode;
    private ManagedProcess? _havenoDaemonProcess;
    private Task? _stdoutReadTask;

    public HavenoDaemonArguments HavenoDaemonArguments { get; }

    public HavenoDaemon(
        string havenoDaemonPath,
        HavenoDaemonArguments havenoDaemonArguments)
    {
        HavenoDaemonArguments = havenoDaemonArguments;
        _havenoDaemonPath = havenoDaemonPath;
    }

    public HavenoDaemon(
        string havenoDaemonPath,
        HavenoDaemonArguments havenoDaemonArguments,
        bool isSeedNode)
    {
        HavenoDaemonArguments = havenoDaemonArguments;
        _havenoDaemonPath = havenoDaemonPath;
        _isSeedNode = isSeedNode;
    }

    public void Dispose()
    {
        if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows) && !RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            return;

        _havenoDaemonProcess?.Dispose();
        _havenoDaemonProcess?.WaitForExit();

        _stdoutReadTask?.Wait();

        GC.SuppressFinalize(this);
    }

    // Handle if already running
    public async Task StartAsync()
    {
        string daemonPath;
        if (File.Exists(_havenoDaemonPath))
        {
            // Provide a path to a file which can be either a jar or executable
            daemonPath = _havenoDaemonPath;
        }
        else if (Directory.Exists(_havenoDaemonPath))
        {
            // Or provide a path to a directory which contains a daemon jar file
            daemonPath = Path.Combine(_havenoDaemonPath, $"daemon-{(RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "windows" : "linux-x86_64")}.jar");
            if (!File.Exists(daemonPath))
            {
                throw new HavenoException($"No Haveno daemon jar file found at path: \"{_havenoDaemonPath}\".");
            }
        }
        else
        {
            throw new HavenoException("Path was not a file or directory.");
        }

        ProcessStartInfo processStartInfo;

        if (daemonPath.EndsWith(".jar"))
        {
            processStartInfo = new("java");
            processStartInfo.ArgumentList.Add("-jar");
            processStartInfo.ArgumentList.Add(daemonPath);
        }
        else
        {
            processStartInfo = new(daemonPath);
        }

        processStartInfo.RedirectStandardOutput = true;
        processStartInfo.RedirectStandardError = true;
        processStartInfo.UseShellExecute = false;
        processStartInfo.CreateNoWindow = true;

        string[] arguments = [
            HavenoDaemonArguments.UserDataDir is null ? string.Empty : $"--userDataDir={HavenoDaemonArguments.UserDataDir}",
            HavenoDaemonArguments.ApiPassword is null ? string.Empty : $"--apiPassword={HavenoDaemonArguments.ApiPassword}",
            HavenoDaemonArguments.WalletRpcBindPort is null ? string.Empty : $"--walletRpcBindPort={HavenoDaemonArguments.WalletRpcBindPort}",
            HavenoDaemonArguments.XmrNode is null ? string.Empty : $"--xmrNode={HavenoDaemonArguments.XmrNode}",
            HavenoDaemonArguments.AppDataDir is null ? string.Empty : $"--appDataDir={HavenoDaemonArguments.AppDataDir}",
            $"--useLocalhostForP2P={HavenoDaemonArguments.UseLocalhostForP2P ??= false}",
            $"--useDevPrivilegeKeys={HavenoDaemonArguments.UseDevPrivilegeKeys ??= false}",
            $"--disableRateLimits={HavenoDaemonArguments.DisableRateLimits ??= false}",
            $"--useNativeXmrWallet={HavenoDaemonArguments.UseNativeXmrWallet ??= false}",
            $"--passwordRequired={HavenoDaemonArguments.PasswordRequired ??= false}",
            $"--baseCurrencyNetwork={HavenoDaemonArguments.NetworkType ??= HavenoNetworkType.XMR_MAINNET}",
            $"--logLevel={HavenoDaemonArguments.LogLevel ??= "INFO"}",
            $"--nodePort={HavenoDaemonArguments.NodePort ??= 11111}",
            $"--apiPort={HavenoDaemonArguments.ApiPort ??= 3201}",
            $"--appName={HavenoDaemonArguments.AppName ??= $"haveno-daemon-{HavenoDaemonArguments.NetworkType ?? HavenoNetworkType.XMR_MAINNET}"}"
        ];

        foreach (string argument in arguments)
        {
            processStartInfo.ArgumentList.Add(argument);
        }

        // Gets rid of warning
        if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows) && !RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            return;

        _havenoDaemonProcess = ManagedProcess.Start(processStartInfo);

        _ = Task.Factory.StartNew(async () =>
        {
            string? line;
            while ((line = await _havenoDaemonProcess.StandardError.ReadLineAsync()) is not null)
            {
                Debug.WriteLine($"Havenod: {line}");
            }
        }, TaskCreationOptions.LongRunning);

        var daemonReadyTCS = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        _stdoutReadTask = Task.Factory.StartNew(async () =>
        {
            try
            {
                string? line;
                while ((line = await _havenoDaemonProcess.StandardOutput.ReadLineAsync()) is not null)
                {
                    Debug.WriteLine($"Havenod: {line}");

                    if (!daemonReadyTCS.Task.IsCompleted)
                    {
                        if (_isSeedNode && line.Contains("onHiddenServicePublished"))
                        {
                            daemonReadyTCS.SetResult();
                        }
                        else
                        {
                            if (HavenoDaemonArguments.PasswordRequired.Value)
                            {
                                if (line.Contains("Interactive login required"))
                                {
                                    daemonReadyTCS.SetResult();
                                }
                            }
                            else
                            {
                                if (line.Contains("Application fully initialized"))
                                {
                                    daemonReadyTCS.SetResult();
                                }
                            }
                        }
                    }
                }
            }
            catch (ObjectDisposedException)
            {
                return;
            }
        }, TaskCreationOptions.LongRunning);

        await daemonReadyTCS.Task;
    }
}

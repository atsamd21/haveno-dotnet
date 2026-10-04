using Haveno.Api.Models;
using Haveno.Api.Services;
using Haveno.Tests.Helpers;
using Haveno.Tests.Wallet;
using Microsoft.Extensions.DependencyInjection;
using Xunit.Extensions.Ordering;

namespace Haveno.Tests;

[Order(4)]
[Collection(nameof(SetupCollection))]
[TestCaseOrderer("Haveno.Tests.PriorityOrderer", "haveno-dotnet.Tests")]
public class WalletServiceTests
{
    private readonly IWalletService _walletService;
    private readonly MoneroWalletService _moneroWalletService;

    private readonly IAccountService _accountService;

    public WalletServiceTests(SetupFixture fixture)
    {
        var serviceProvider = fixture.ServiceProvider;
        _walletService = serviceProvider.GetRequiredKeyedService<IWalletService>("user_1");
        _moneroWalletService = serviceProvider.GetRequiredService<MoneroWalletService>();

        _accountService = serviceProvider.GetRequiredKeyedService<IAccountService>("user_1");
    }

    [Fact, TestPriority(10)]
    public async Task GetXmrPrimaryAddress_Should_Return_Valid_Address()
    {
        var response = await _walletService.GetXmrPrimaryAddressAsync();

        Assert.Equal(95, response.Length);
    }

    [Fact, TestPriority(20)]
    public async Task Wallet_Should_Have_Funds()
    {
        await WalletHelper.FundHavenoWallet(_walletService, _moneroWalletService);

        var response = await _walletService.GetBalancesAsync();
        Assert.True(response.AvailableBalance >= 10_000_000_000_000u);
    }

    [Fact, TestPriority(30)]
    public async Task GetXmrSeed_Should_Return_Valid_Seed()
    {
        var response = await _walletService.GetXmrSeedAsync();
        Assert.NotEmpty(response);

        var words = response.Split(" ");
        Assert.Equal(25, words.Length);
    }

    [Fact, TestPriority(40)]
    public async Task Create_And_Send_Transaction()
    {
        var createXmrTxResponse = await _walletService.CreateXmrTxAsync([ new XmrDestination { Address = "9tsUiG9bwcU7oTbAdBwBk2PzxFtysge5qcEsHEpetmEKgerHQa1fDqH7a4FiquZmms7yM22jdifVAD7jAb2e63GSJMuhY75", Amount = 1_000_000_000_000 } ]);

        var destination = createXmrTxResponse.OutgoingTransfer?.Destinations.FirstOrDefault();

        Assert.NotNull(destination);
        Assert.Equal("9tsUiG9bwcU7oTbAdBwBk2PzxFtysge5qcEsHEpetmEKgerHQa1fDqH7a4FiquZmms7yM22jdifVAD7jAb2e63GSJMuhY75", destination.Address);
        Assert.Equal(1_000_000_000_000u, destination.Amount);

        var relayTxResponse = await _walletService.RelayXmrTxsAsync([ createXmrTxResponse.Metadata ]);
        Assert.NotEmpty(relayTxResponse);
    }

    [Fact, TestPriority(50)]
    public async Task Create_And_Send_Sweep_Transaction()
    {
        var createXmrSweepTxResponse = await _walletService.CreateXmrSweepTxsAsync("9tsUiG9bwcU7oTbAdBwBk2PzxFtysge5qcEsHEpetmEKgerHQa1fDqH7a4FiquZmms7yM22jdifVAD7jAb2e63GSJMuhY75");

        var sweepTx = createXmrSweepTxResponse.FirstOrDefault();
        Assert.NotNull(sweepTx);

        var outgoingTransfer = sweepTx.OutgoingTransfer?.Destinations.FirstOrDefault();
        Assert.NotNull(outgoingTransfer);

        Assert.Equal("9tsUiG9bwcU7oTbAdBwBk2PzxFtysge5qcEsHEpetmEKgerHQa1fDqH7a4FiquZmms7yM22jdifVAD7jAb2e63GSJMuhY75", outgoingTransfer.Address);

        var relayTxResponse = await _walletService.RelayXmrTxsAsync([sweepTx.Metadata]);
        Assert.NotEmpty(relayTxResponse);
    }

    [Fact, TestPriority(60)]
    public async Task Get_Xmr_Txs()
    {
        var response = await _walletService.GetXmrTxsAsync();
        Assert.NotEmpty(response);
    }

    [Fact, TestPriority(70)]
    public async Task Get_New_Subaddress_Address()
    {
        var response = await _walletService.GetXmrNewSubaddressAsync();
        Assert.Equal(95, response.Length);
    }
}

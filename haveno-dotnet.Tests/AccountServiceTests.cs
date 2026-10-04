using Grpc.Core;
using Haveno.Api.Services;
using Microsoft.Extensions.DependencyInjection;
using Xunit.Extensions.Ordering;

namespace Haveno.Tests;

[Order(1)]
[Collection(nameof(SetupCollection))]
[TestCaseOrderer("Haveno.Tests.PriorityOrderer", "haveno-dotnet.Tests")]
public class AccountServiceTests
{
    private readonly IAccountService _accountService;
    private readonly IVersionService _versionService;
    private readonly IWalletService _walletService;

    public AccountServiceTests(SetupFixture fixture)
    {
        var serviceProvider = fixture.ServiceProvider;
        _accountService = serviceProvider.GetRequiredKeyedService<IAccountService>("user_1");
        _versionService = serviceProvider.GetRequiredKeyedService<IVersionService>("user_1");
        _walletService = serviceProvider.GetRequiredKeyedService<IWalletService>("user_1");
    }

    private async Task WaitAPIIsOnlineAsync()
    {
        for (int i = 0; i < 20; i++)
        {
            await Task.Delay(1_000);

            try
            {
                await _versionService.GetVersionAsync();
                return;
            }
            catch
            {

            }
        }

        throw new Exception("Timed out");
    }

    private async Task WaitAppInitializedAsync()
    {
        for (int i = 0; i < 30; i++)
        {
            await Task.Delay(1_000);

            try
            {
               if (await _accountService.IsAppInitializedAsync())
                    return;
            }
            catch
            {

            }
        }

        throw new Exception("Timed out");
    }

    [Fact, TestPriority(20)]
    public async Task Account_Should_Close_And_Open()
    {
        await _accountService.CloseAccountAsync();
        Assert.False(await _accountService.IsAccountOpenAsync());

        await _accountService.OpenAccountAsync(SetupFixture.AccountPassword);
        Assert.True(await _accountService.IsAccountOpenAsync());
    }

    [Fact, TestPriority(30)]
    public async Task DeleteAccount()
    {
        await _accountService.DeleteAccountAsync();
        await WaitAPIIsOnlineAsync();

        Assert.False(await _accountService.AccountExistsAsync());

        // Recreate account
        await _accountService.CreateAccountAsync(SetupFixture.AccountPassword);
        await WaitAppInitializedAsync();

        Assert.True(await _accountService.AccountExistsAsync());

        await _accountService.OpenAccountAsync(SetupFixture.AccountPassword);
        await WaitAppInitializedAsync();

        Assert.True(await _accountService.IsAccountOpenAsync());
    }

    [Fact, TestPriority(40)]
    public async Task CreateAccount_Should_Throw_Rpc_Exception()
    {
        var exception = await Assert.ThrowsAsync<RpcException>(async () => await _accountService.CreateAccountAsync(SetupFixture.AccountPassword));
        Assert.Equal("Status(StatusCode=\"Unknown\", Detail=\"Cannot create account if account already exists\")", exception.Message);
    }

    [Fact, TestPriority(50)]
    public async Task CreateAccount_Should_Create_New_Account()
    {
        await _accountService.DeleteAccountAsync();
        await WaitAPIIsOnlineAsync();

        Assert.False(await _accountService.AccountExistsAsync());

        await _accountService.CreateAccountAsync(SetupFixture.AccountPassword);
        await _accountService.OpenAccountAsync(SetupFixture.AccountPassword);
        await WaitAppInitializedAsync();

        Assert.True(await _accountService.AccountExistsAsync());
        Assert.True(await _accountService.IsAccountOpenAsync());
    }

    [Fact, TestPriority(60)]
    public async Task ChangePassword()
    {
        var address_1 = await _walletService.GetXmrPrimaryAddressAsync();

        await _accountService.ChangePasswordAsync(SetupFixture.AccountPassword, SetupFixture.AccountPassword += "new");

        await _accountService.OpenAccountAsync(SetupFixture.AccountPassword);
        await WaitAppInitializedAsync();

        Assert.True(await _accountService.IsAccountOpenAsync());

        var address_2 = await _walletService.GetXmrPrimaryAddressAsync();

        Assert.True(address_1 == address_2);
    }

    [Fact, TestPriority(70)]
    public async Task RestoreAccount()
    {
        var address_1 = await _walletService.GetXmrPrimaryAddressAsync();

        var backupResponse = await _accountService.BackupAccountAsStreamAsync();
        await WaitAppInitializedAsync();

        await _accountService.DeleteAccountAsync();
        await WaitAPIIsOnlineAsync();

        Assert.False(await _accountService.AccountExistsAsync());

        await _accountService.RestoreAccountAsync(backupResponse);
        await WaitAPIIsOnlineAsync();

        Assert.True(await _accountService.AccountExistsAsync());

        await _accountService.OpenAccountAsync(SetupFixture.AccountPassword);
        await WaitAppInitializedAsync();

        Assert.True(await _accountService.IsAccountOpenAsync());

        var address_2 = await _walletService.GetXmrPrimaryAddressAsync();

        // Make sure wallet got backed up
        Assert.True(address_1 == address_2);
    }
}

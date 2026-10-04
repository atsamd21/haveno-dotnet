using Haveno.Api.Services;
using Haveno.Tests.Wallet;

namespace Haveno.Tests.Helpers;

public static class WalletHelper
{
    private static readonly SemaphoreSlim semaphore = new(1, 1);

    public static async Task FundHavenoWallet(IWalletService walletService, MoneroWalletService moneroWalletService)
    {
        await semaphore.WaitAsync();

        try
        {
            await moneroWalletService.StartMiningAsync(1, false, true);

            var address = await walletService.GetXmrPrimaryAddressAsync();

            for (int i = 0; i < 11; i++)
            {
                if (await moneroWalletService.TransferAsync(1_000_000_000_000, 0, address, [], false) is null)
                    throw new Exception("Could not transfer funds from funding wallet.");
            }

            for (int i = 0; i < 60; i++)
            {
                if ((await walletService.GetBalancesAsync()).AvailableBalance >= 10_000_000_000_000u)
                {
                    return;
                }

                await Task.Delay(1_000);
            }

            throw new Exception("Timed out waiting for funds to arrive.");
        }
        finally
        {
            try
            {
                await moneroWalletService.StopMiningAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Failed to stop mining, error: {e}");
            }

            semaphore.Release();
        }
    }
}

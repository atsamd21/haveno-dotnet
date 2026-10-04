using Haveno.Tests.Wallet.Requests;
using Haveno.Tests.Wallet.Responses;

namespace Haveno.Tests.Wallet;

public class MoneroWalletService : IDisposable
{
    private readonly HttpClient _httpClient;
    private readonly MoneroRPCClient _moneroRPCClient;

    public MoneroWalletService()
    {
        _httpClient = new();
        // Address/port houldn't be hardcoded
        _moneroRPCClient = new MoneroRPCClient(_httpClient, "127.0.0.1", 28084);
    }

    private static T UnwrapAndValidateResponse<T>(BaseResponse<T>? response)
    {
        if (response is null)
        {
            throw new Exception("Response is null.");
        }
        else if (!string.IsNullOrEmpty(response.Error?.Message))
        {
            throw new Exception($"Wallet RPC error: {response.Error?.Message}");
        }

        return response.Result ?? throw new Exception("Result is null.");
    }

    public async Task<GetBalanceResponse?> GetBalanceAsync(uint accountIndex, uint[] indices)
    {
        var request = new ExtendedBaseRequest<GetBalanceRequest>("get_balance");
        request.Params.AccountIndex = accountIndex;
        request.Params.AddressIndices = indices;

        return UnwrapAndValidateResponse(await _moneroRPCClient.GetAsync<GetBalanceResponse>(request));
    }

    public async Task<RefreshResponse> RefreshWalletAsync()
    {
        var request = new ExtendedBaseRequest<RefreshRequest>("refresh");

        return UnwrapAndValidateResponse(await _moneroRPCClient.GetAsync<RefreshResponse>(request));
    }

    public async Task<RestoreDeterministicWalletResponse> RestoreDeterministicWallet(string walletName, string seed)
    {
        var request = new ExtendedBaseRequest<RestoreDeterministicWalletRequest>("restore_deterministic_wallet");
        request.Params.Filename = walletName;
        request.Params.Seed = seed;

        return UnwrapAndValidateResponse(await _moneroRPCClient.GetAsync<RestoreDeterministicWalletResponse>(request));
    }

    public async Task<QueryKeyResponse> QueryKey()
    {
        var request = new ExtendedBaseRequest<QueryKeyRequest>("query_key");

        return UnwrapAndValidateResponse(await _moneroRPCClient.GetAsync<QueryKeyResponse>(request));
    }

    public async Task CreateWalletAsync(string walletName, string? password = null, string? language = null)
    {
        var request = new ExtendedBaseRequest<CreateWalletRequest>("create_wallet");
        request.Params.Filename = walletName;
        //request.Params.Password = password;
        //request.Params.Language = language;

        UnwrapAndValidateResponse(await _moneroRPCClient.GetAsync<object>(request));
    }

    public async Task OpenWalletAsync(string walletName)
    {
        var request = new ExtendedBaseRequest<OpenWalletRequest>("open_wallet");
        request.Params.Filename = walletName;

        UnwrapAndValidateResponse(await _moneroRPCClient.GetAsync<object>(request));
    }

    public async Task<GetAddressResponse?> GetAddressAsync()
    {
        var request = new ExtendedBaseRequest<GetAddressRequest>("get_address");

        return UnwrapAndValidateResponse(await _moneroRPCClient.GetAsync<GetAddressResponse>(request));
    }

    public async Task<GetFeeResponse?> GetRealFeeAsync(ulong amount, uint fromAccount, string toAddress, uint[] subbaddressIndices)
    {
        var request = new ExtendedBaseRequest<TransferRequest>("transfer");
        request.Params.AccountIndex = fromAccount;
        request.Params.DoNotRelay = true;
        request.Params.Destinations = [new Destination { Address = toAddress, Amount = amount }];
        request.Params.SubaddressIndices = subbaddressIndices;

        var response = UnwrapAndValidateResponse(await _moneroRPCClient.GetAsync<TransferResponse>(request));

        return new GetFeeResponse 
        { 
            Fee = response.Fee, 
            TxMetadata = response.TxMetadata 
        };
    }

    public async Task StartMiningAsync(uint threadsCount, bool doBackgroundMining, bool ignoreBattery)
    {
        var request = new ExtendedBaseRequest<StartMiningRequest>("start_mining");
        request.Params.ThreadsCount = threadsCount;
        request.Params.DoBackgroundMining = doBackgroundMining;
        request.Params.IgnoreBattery = ignoreBattery;

        UnwrapAndValidateResponse(await _moneroRPCClient.GetAsync<object>(request));
    }

    public async Task StopMiningAsync()
    {
        var request = new ExtendedBaseRequest<StopMiningRequest>("stop_mining");
        UnwrapAndValidateResponse(await _moneroRPCClient.GetAsync<object>(request));
    }

    public async Task<TransferResponse?> TransferAsync(ulong amount, uint fromAccountIndex, string toAddress, uint[] subbaddressIndices, bool subtractFee)
    {
        if (subtractFee)
        {
            var feeResponse = await GetRealFeeAsync(amount, fromAccountIndex, toAddress, subbaddressIndices);

            if (feeResponse is not null)
            {
                var minusFeeRequest = new ExtendedBaseRequest<TransferRequest>("transfer");
                minusFeeRequest.Params.AccountIndex = fromAccountIndex;
                minusFeeRequest.Params.SubaddressIndices = subbaddressIndices;
                minusFeeRequest.Params.Destinations = [new Destination { Address = toAddress, Amount = amount - feeResponse.Fee }];

                var minusFeeResponse = await _moneroRPCClient.GetAsync<TransferResponse>(minusFeeRequest);

                if (minusFeeResponse is null || minusFeeResponse.Result is null)
                    return default;

                return minusFeeResponse.Result;
            }
            else return default;
        }

        var request = new ExtendedBaseRequest<TransferRequest>("transfer");
        request.Params.Destinations = [new Destination { Address = toAddress, Amount = amount }];
        request.Params.AccountIndex = fromAccountIndex;
        request.Params.SubaddressIndices = subbaddressIndices;

        return UnwrapAndValidateResponse(await _moneroRPCClient.GetAsync<TransferResponse>(request));
    }

    public void Dispose()
    {
        _httpClient.Dispose();
        GC.SuppressFinalize(this);
    }
}

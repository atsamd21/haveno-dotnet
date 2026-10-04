using Haveno.Api.Models;
using Haveno.Api.Models.Converters;
using Haveno.Api.Models.Responses;
using Haveno.Api.Singletons;
using Haveno.Proto.Clients;
using ProtoBuf.Grpc.Client;

namespace Haveno.Api.Services;

public interface IWalletService
{
    Task<XmrBalanceInfo> GetBalancesAsync(CancellationToken cancellationToken = default);
    Task<string> GetXmrSeedAsync(CancellationToken cancellationToken = default);
    Task<string> GetXmrPrimaryAddressAsync(CancellationToken cancellationToken = default);
    Task<string> GetXmrNewSubaddressAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<XmrTx>> GetXmrTxsAsync(CancellationToken cancellationToken = default);
    Task<XmrTx> CreateXmrTxAsync(List<XmrDestination> xmrDestinations, CancellationToken cancellationToken = default);
    Task<IEnumerable<XmrTx>> CreateXmrSweepTxsAsync(string address, CancellationToken cancellationToken = default);
    Task<IEnumerable<string>> RelayXmrTxsAsync(List<string> metadatas, CancellationToken cancellationToken = default);
    Task<GetWalletHeightResponse> GetHeightAsync(CancellationToken cancellationToken = default);
}

public sealed class WalletService : IWalletService
{
    private readonly GrpcChannelSingleton _grpcChannelSingleton;
    private readonly IHavenoWalletClient _havenoWalletClient;

    public WalletService(GrpcChannelSingleton grpcChannelSingleton)
    {
        _grpcChannelSingleton = grpcChannelSingleton;
        _havenoWalletClient = _grpcChannelSingleton.Channel.CreateGrpcService<IHavenoWalletClient>();
    }

    public async Task<XmrBalanceInfo> GetBalancesAsync(CancellationToken cancellationToken = default)
    {
        var response = await _havenoWalletClient.GetBalancesAsync(
            new Proto.Models.Requests.GetBalancesRequest(),
            cancellationToken);

        return new XmrBalanceInfo
        {
            AvailableBalance = checked((ulong)response.Balances.Xmr.AvailableBalance),
            Balance = checked((ulong)response.Balances.Xmr.Balance),
            PendingBalance = checked((ulong)response.Balances.Xmr.PendingBalance),
            ReservedOfferBalance = checked((ulong)response.Balances.Xmr.ReservedOfferBalance),
            ReservedTradeBalance = checked((ulong)response.Balances.Xmr.ReservedTradeBalance),
        };
    }

    public async Task<string> GetXmrSeedAsync(CancellationToken cancellationToken = default)
    {
        var response = await _havenoWalletClient.GetXmrSeedAsync(
            new Proto.Models.Requests.GetXmrSeedRequest(),
            cancellationToken);

        return response.Seed;
    }

    public async Task<string> GetXmrPrimaryAddressAsync(CancellationToken cancellationToken = default)
    {
        var response = await _havenoWalletClient.GetXmrPrimaryAddressAsync(
            new Proto.Models.Requests.GetXmrPrimaryAddressRequest(),
            cancellationToken);

        return response.PrimaryAddress;
    }

    public async Task<string> GetXmrNewSubaddressAsync(CancellationToken cancellationToken = default)
    {
        var response = await _havenoWalletClient.GetXmrNewSubaddressAsync(
            new Proto.Models.Requests.GetXmrNewSubaddressRequest(),
            cancellationToken);

        return response.Subaddress;
    }

    public async Task<IEnumerable<XmrTx>> GetXmrTxsAsync(CancellationToken cancellationToken = default)
    {
        var response = await _havenoWalletClient.GetXmrTxsAsync(
            new Proto.Models.Requests.GetXmrTxsRequest(),
            cancellationToken);

        return response.Txs.Select(x => x.Convert());
    }

    public async Task<XmrTx> CreateXmrTxAsync(List<XmrDestination> xmrDestinations, CancellationToken cancellationToken = default)
    {
        var response = await _havenoWalletClient.CreateXmrTxAsync(
             new Proto.Models.Requests.CreateXmrTxRequest
             {
                 Destinations = xmrDestinations.Select(x => new Proto.Models.XmrDestination
                 {
                     Address = x.Address,
                     Amount =  x.Amount.ToString()
                 }).ToList(),
             },
             cancellationToken);

        return response.Tx.Convert();
    }

    public async Task<IEnumerable<XmrTx>> CreateXmrSweepTxsAsync(string address, CancellationToken cancellationToken = default)
    {
        var response = await _havenoWalletClient.CreateXmrSweepTxsAsync(
             new Proto.Models.Requests.CreateXmrSweepTxsRequest
             {
                 Address = address,
             },
             cancellationToken);

        return response.Txs.Select(x => x.Convert());
    }

    public async Task<IEnumerable<string>> RelayXmrTxsAsync(List<string> metadatas, CancellationToken cancellationToken = default)
    {
        var response = await _havenoWalletClient.RelayXmrTxsAsync(
            new Proto.Models.Requests.RelayXmrTxsRequest
            {
                Metadatas = metadatas
            },
            cancellationToken);

        return response.Hashes;
    }

    public async Task<GetWalletHeightResponse> GetHeightAsync(CancellationToken cancellationToken = default)
    {
        var response = await _havenoWalletClient.GetHeightAsync(
            new Proto.Models.Requests.GetWalletHeightRequest(),
            cancellationToken);

        return new GetWalletHeightResponse
        {
            Height = response.Height,
            TargetHeight = response.TargetHeight
        };
    }
}

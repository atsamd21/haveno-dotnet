using Haveno.Api.Models;
using Haveno.Api.Singletons;
using Haveno.Extensions;
using Haveno.Proto.Clients;
using ProtoBuf.Grpc.Client;

namespace Haveno.Api.Services;

public interface ITradeStatisticsService
{
    Task<IEnumerable<TradeStatistic>> GetTradeStatisticsAsync(CancellationToken cancellationToken = default);
}

public sealed class TradeStatisticsService : ITradeStatisticsService
{
    private readonly GrpcChannelSingleton _grpcChannelSingleton;
    private readonly IHavenoGetTradeStatisticsClient _havenoGetTradeStatisticsClient;

    public TradeStatisticsService(GrpcChannelSingleton grpcChannelSingleton)
    {
        _grpcChannelSingleton = grpcChannelSingleton;
        _havenoGetTradeStatisticsClient = _grpcChannelSingleton.Channel.CreateGrpcService<IHavenoGetTradeStatisticsClient>();
    }

    public async Task<IEnumerable<TradeStatistic>> GetTradeStatisticsAsync(CancellationToken cancellationToken = default)
    {
        var response = await _havenoGetTradeStatisticsClient.GetTradeStatisticsAsync(
            new Proto.Models.Requests.GetTradeStatisticsRequest(), 
            cancellationToken);

        return response.TradeStatistics3.Select(x => new TradeStatistic
        {
            Amount = checked((ulong)x.Amount),
            Price = checked((ulong)x.Price),
            Arbitrator = x.Arbitrator,
            Currency = x.Currency,
            Date = x.Date.ToDateTime(),
            ExtraData = x.ExtraData,
            Hash = x.Hash,
            MakerDepositTxId = x.MakerDepositTxId,
            TakerDepositTxId = x.MakerDepositTxId,
            PaymentMethod = x.PaymentMethod
        });
    }
}

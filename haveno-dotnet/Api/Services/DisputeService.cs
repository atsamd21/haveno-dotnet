using Haveno.Api.Models;
using Haveno.Api.Models.Converters;
using Haveno.Api.Models.Requests;
using Haveno.Api.Singletons;
using Haveno.Proto.Clients;
using ProtoBuf.Grpc.Client;

namespace Haveno.Api.Services;

public interface IDisputeService
{
    Task<Dispute> GetDisputeAsync(string tradeId, CancellationToken cancellationToken = default);
    Task<IEnumerable<Dispute>> GetDisputesAsync( CancellationToken cancellationToken = default);
    Task OpenDisputeAsync(string tradeId, CancellationToken cancellationToken = default);
    Task ResolveDisputeAsync(ResolveDisputeRequest resolveDisputeRequest, CancellationToken cancellationToken = default);
    Task SendDisputeChatMessageAsync(SendDisputeChatMessageRequest sendDisputeChatMessageRequest, CancellationToken cancellationToken = default);
}

public sealed class DisputeService : IDisputeService
{
    private readonly GrpcChannelSingleton _grpcChannelSingleton;
    private readonly IHavenoDisputesClient _havenoDisputesClient;

    public DisputeService(GrpcChannelSingleton grpcChannelSingleton)
    {
        _grpcChannelSingleton = grpcChannelSingleton;
        _havenoDisputesClient = _grpcChannelSingleton.Channel.CreateGrpcService<IHavenoDisputesClient>();
    }

    public async Task<Dispute> GetDisputeAsync(string tradeId, CancellationToken cancellationToken = default)
    {
        var response = await _havenoDisputesClient.GetDisputeAsync(
            new Proto.Models.Requests.GetDisputeRequest
            {
                TradeId = tradeId,
            },
            cancellationToken);

        return response.Dispute.Convert();
    }

    public async Task<IEnumerable<Dispute>> GetDisputesAsync(CancellationToken cancellationToken = default)
    {
        var response = await _havenoDisputesClient.GetDisputesAsync(
            new Proto.Models.Requests.GetDisputesRequest(),
            cancellationToken);

        return response.Disputes.Select(x => x.Convert());
    }

    public async Task OpenDisputeAsync(string tradeId, CancellationToken cancellationToken = default)
    {
        await _havenoDisputesClient.OpenDisputeAsync(new Proto.Models.Requests.OpenDisputeRequest
        {
            TradeId = tradeId
        }, 
        cancellationToken);
    }

    public async Task ResolveDisputeAsync(ResolveDisputeRequest resolveDisputeRequest, CancellationToken cancellationToken = default)
    {
        await _havenoDisputesClient.ResolveDisputeAsync(new Proto.Models.Requests.ResolveDisputeRequest
        {
            CustomPayoutAmount = resolveDisputeRequest.CustomPayoutAmount,
            Reason = resolveDisputeRequest.Reason,
            SummaryNotes = resolveDisputeRequest.SummaryNotes,
            TradeId = resolveDisputeRequest.TradeId,
            Winner = resolveDisputeRequest.Winner
        }, 
        cancellationToken);
    }

    public async Task SendDisputeChatMessageAsync(SendDisputeChatMessageRequest sendDisputeChatMessageRequest, CancellationToken cancellationToken = default)
    {
        await _havenoDisputesClient.SendDisputeChatMessageAsync(new Proto.Models.Requests.SendDisputeChatMessageRequest
        {
            Attachments = sendDisputeChatMessageRequest.Attachments.Select(x => x.Convert()).ToList(),
            DisputeId = sendDisputeChatMessageRequest.DisputeId,
            Message = sendDisputeChatMessageRequest.Message
        },
        cancellationToken);
    }
}

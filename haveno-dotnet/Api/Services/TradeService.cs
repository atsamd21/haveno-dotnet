using Haveno.Api.Models;
using Haveno.Api.Models.Converters;
using Haveno.Api.Models.Requests;
using Haveno.Api.Models.Responses;
using Haveno.Api.Singletons;
using Haveno.Proto.Clients;
using Haveno.Shared.Enums;
using ProtoBuf.Grpc.Client;

namespace Haveno.Api.Services;

public interface ITradeService
{
    Task<TradeInfo> GetTradeAsync(string tradeId, CancellationToken cancellationToken = default);
    Task<IEnumerable<TradeInfo>> GetTradesAsync(Category category, CancellationToken cancellationToken = default);
    Task<TakeOfferResponse> TakeOfferAsync(TakeOfferRequest takeOfferRequest, CancellationToken cancellationToken = default);
    Task ConfirmPaymentSentAsync(string tradeId, CancellationToken cancellationToken = default);
    Task ConfirmPaymentReceivedAsync(string tradeId, CancellationToken cancellationToken = default);
    Task CompleteTradeAsync(string tradeId, CancellationToken cancellationToken = default);
    //Task WithdrawFundsAsync(WithdrawFundsRequest withdrawFundsRequest, CancellationToken cancellationToken = default);
    Task<IEnumerable<ChatMessage>> GetChatMessagesAsync(string tradeId, CancellationToken cancellationToken = default);
    Task SendChatMessageAsync(string tradeId, string message, CancellationToken cancellationToken = default);
}

public sealed class TradeService : ITradeService
{
    private readonly GrpcChannelSingleton _grpcChannelSingleton;
    private readonly IHavenoTradesClient _havenoTradesClient;

    public TradeService(GrpcChannelSingleton grpcChannelSingleton)
    {
        _grpcChannelSingleton = grpcChannelSingleton;
        _havenoTradesClient = _grpcChannelSingleton.Channel.CreateGrpcService<IHavenoTradesClient>();
    }

    public async Task CompleteTradeAsync(string tradeId, CancellationToken cancellationToken = default)
    {
        await _havenoTradesClient.CompleteTradeAsync(
            new Proto.Models.Requests.CompleteTradeRequest 
            { 
                TradeId = tradeId 
            }, 
            cancellationToken);
    }

    public async Task ConfirmPaymentReceivedAsync(string tradeId, CancellationToken cancellationToken = default)
    {
        await _havenoTradesClient.ConfirmPaymentReceivedAsync(
            new Proto.Models.Requests.ConfirmPaymentReceivedRequest
            {
                TradeId = tradeId
            },
            cancellationToken);
    }

    public async Task ConfirmPaymentSentAsync(string tradeId, CancellationToken cancellationToken = default)
    {
        await _havenoTradesClient.ConfirmPaymentSentAsync(
            new Proto.Models.Requests.ConfirmPaymentSentRequest
            {
                TradeId = tradeId
            },
            cancellationToken);
    }

    public async Task<IEnumerable<ChatMessage>> GetChatMessagesAsync(string tradeId, CancellationToken cancellationToken = default)
    {
        var response = await _havenoTradesClient.GetChatMessagesAsync(
            new Proto.Models.Requests.GetChatMessagesRequest
            {
                TradeId = tradeId
            }, 
            cancellationToken);

        return response.Message.Select(x => x.Convert());
    }

    public async Task<TradeInfo> GetTradeAsync(string tradeId, CancellationToken cancellationToken = default)
    {
        var response = await _havenoTradesClient.GetTradeAsync(
            new Proto.Models.Requests.GetTradeRequest
            {
                TradeId = tradeId
            },
            cancellationToken);

        return response.Trade.Convert();
    }

    public async Task<IEnumerable<TradeInfo>> GetTradesAsync(Category category, CancellationToken cancellationToken = default)
    {
        var response = await _havenoTradesClient.GetTradesAsync(
            new Proto.Models.Requests.GetTradesRequest
            {
                Category = category
            },
            cancellationToken);

        return response.Trades.Select(x => x.Convert());
    }

    public async Task SendChatMessageAsync(string tradeId, string message, CancellationToken cancellationToken = default)
    {
        await _havenoTradesClient.SendChatMessageAsync(
            new Proto.Models.Requests.SendChatMessageRequest
            {
                TradeId = tradeId,
                Message = message
            },
            cancellationToken);
    }

    public async Task<TakeOfferResponse> TakeOfferAsync(TakeOfferRequest takeOfferRequest, CancellationToken cancellationToken = default)
    {
        var response = await _havenoTradesClient.TakeOfferAsync(
            new Proto.Models.Requests.TakeOfferRequest
            {
                Amount = takeOfferRequest.Amount,
                PaymentAccountId = takeOfferRequest.PaymentAccountId,
                Challenge = takeOfferRequest.Challenge,
                OfferId = takeOfferRequest.OfferId
            },
            cancellationToken);

        return new TakeOfferResponse
        {
            Trade = response.Trade.Convert(),
            AvailabilityResultWithDescription = response.AvailabilityResultWithDescription is null ? null : new AvailabilityResultWithDescription
            {
                AvailabilityResult = response.AvailabilityResultWithDescription.AvailabilityResult,
                Description = response.AvailabilityResultWithDescription.Description
            }
        };
    }
}

using Haveno.Proto.Models.Replies;
using Haveno.Proto.Models.Requests;
using System.Runtime.CompilerServices;
using System.ServiceModel;

[assembly: InternalsVisibleTo("ProtoBuf.Grpc.Internal.Proxies")]

namespace Haveno.Proto.Clients;

[ServiceContract(Name = "io.haveno.protobuffer.Trades")]
internal interface IHavenoTradesClient
{
    [OperationContract(Name = "GetTrade")]
    Task<GetTradeReply> GetTradeAsync(GetTradeRequest getTradeRequest, CancellationToken cancellationToken = default);
    [OperationContract(Name = "GetTrades")]
    Task<GetTradesReply> GetTradesAsync(GetTradesRequest getTradesRequest, CancellationToken cancellationToken = default);
    [OperationContract(Name = "TakeOffer")]
    Task<TakeOfferReply> TakeOfferAsync(TakeOfferRequest takeOfferRequest, CancellationToken cancellationToken = default);
    [OperationContract(Name = "ConfirmPaymentSent")]
    Task<ConfirmPaymentSentReply> ConfirmPaymentSentAsync(ConfirmPaymentSentRequest confirmPaymentSentRequest, CancellationToken cancellationToken = default);
    [OperationContract(Name = "ConfirmPaymentReceived")]
    Task<ConfirmPaymentReceivedReply> ConfirmPaymentReceivedAsync(ConfirmPaymentReceivedRequest confirmPaymentReceivedRequest, CancellationToken cancellationToken = default);
    [OperationContract(Name = "CompleteTrade")]
    Task<CompleteTradeReply> CompleteTradeAsync(CompleteTradeRequest completeTradeRequest, CancellationToken cancellationToken = default);
    [OperationContract(Name = "WithdrawFunds")]
    Task<WithdrawFundsReply> WithdrawFundsAsync(WithdrawFundsRequest withdrawFundsRequest, CancellationToken cancellationToken = default);
    [OperationContract(Name = "GetChatMessages")]
    Task<GetChatMessagesReply> GetChatMessagesAsync(GetChatMessagesRequest getChatMessagesRequest, CancellationToken cancellationToken = default);
    [OperationContract(Name = "SendChatMessage")]
    Task<SendChatMessageReply> SendChatMessageAsync(SendChatMessageRequest sendChatMessageRequest, CancellationToken cancellationToken = default);
}

using ProtoBuf;

namespace Haveno.Proto.Models.Requests;

[ProtoContract(Name = "ConfirmPaymentSentRequest")]
internal class ConfirmPaymentSentRequest
{
    [ProtoMember(1)]
    public string TradeId { get; set; } = string.Empty;
}

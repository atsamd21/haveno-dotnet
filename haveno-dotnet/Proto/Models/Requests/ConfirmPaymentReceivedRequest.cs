using ProtoBuf;

namespace Haveno.Proto.Models.Requests;

[ProtoContract(Name = "ConfirmPaymentReceivedRequest")]
internal class ConfirmPaymentReceivedRequest
{
    [ProtoMember(1)]
    public string TradeId { get; set; } = string.Empty;
}

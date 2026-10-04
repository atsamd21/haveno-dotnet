using ProtoBuf;

namespace Haveno.Proto.Models.Requests;

[ProtoContract(Name = "TakeOfferRequest")]
internal class TakeOfferRequest
{
    [ProtoMember(1)]
    public string OfferId { get; set; } = string.Empty;
    [ProtoMember(2)]
    public string PaymentAccountId { get; set; } = string.Empty;
    [ProtoMember(3)]
    public ulong Amount { get; set; }
    [ProtoMember(4)]
    public string Challenge { get; set; } = string.Empty;
}

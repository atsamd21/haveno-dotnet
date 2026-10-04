using ProtoBuf;

namespace Haveno.Proto.Models.Replies;

[ProtoContract(Name = "TakeOfferReply")]
internal class TakeOfferReply
{
    [ProtoMember(1)]
    public TradeInfo Trade { get; set; } = new();
    [ProtoMember(2)]
    public AvailabilityResultWithDescription? AvailabilityResultWithDescription { get; set; }
}

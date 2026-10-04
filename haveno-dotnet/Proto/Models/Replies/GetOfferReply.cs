using ProtoBuf;

namespace Haveno.Proto.Models.Replies;

[ProtoContract(Name = "GetOfferReply")]
internal class GetOfferReply
{
    [ProtoMember(1)]
    public OfferInfo Offer { get; set; } = new();
}

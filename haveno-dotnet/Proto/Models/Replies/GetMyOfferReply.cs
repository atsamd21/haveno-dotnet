using ProtoBuf;

namespace Haveno.Proto.Models.Replies;

[ProtoContract(Name = "GetMyOfferReply")]
internal class GetMyOfferReply
{
    [ProtoMember(1)]
    public OfferInfo Offer { get; set; } = new();
}

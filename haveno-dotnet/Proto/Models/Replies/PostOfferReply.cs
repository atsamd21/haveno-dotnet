using ProtoBuf;

namespace Haveno.Proto.Models.Replies;

[ProtoContract(Name = "PostOfferReply")]
internal class PostOfferReply
{
    [ProtoMember(1)]
    public OfferInfo Offer { get; set; } = new();
}


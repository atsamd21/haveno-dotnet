using ProtoBuf;

namespace Haveno.Proto.Models.Replies;

[ProtoContract(Name = "EditOfferReply")]
internal class EditOfferReply
{
    [ProtoMember(1)]
    public OfferInfo Offer { get; set; } = new();
}

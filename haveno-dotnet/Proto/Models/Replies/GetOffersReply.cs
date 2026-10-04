using ProtoBuf;

namespace Haveno.Proto.Models.Replies;

[ProtoContract(Name = "GetOffersReply")]
internal class GetOffersReply
{
    [ProtoMember(1)]
    public List<OfferInfo> Offers { get; set; } = [];
}

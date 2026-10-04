using ProtoBuf;

namespace Haveno.Proto.Models.Replies;

[ProtoContract(Name = "GetMyOffersReply")]
internal class GetMyOffersReply
{
    [ProtoMember(1)]
    public List<OfferInfo> Offers { get; set; } = [];
}

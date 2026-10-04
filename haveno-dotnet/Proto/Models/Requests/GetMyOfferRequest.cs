using ProtoBuf;

namespace Haveno.Proto.Models.Requests;

[ProtoContract(Name = "GetMyOfferRequest")]
internal class GetMyOfferRequest
{
    [ProtoMember(1)]
    public string Id { get; set; } = string.Empty;
}

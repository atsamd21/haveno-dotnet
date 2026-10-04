using ProtoBuf;

namespace Haveno.Proto.Models.Requests;

[ProtoContract(Name = "GetOfferRequest")]
internal class GetOfferRequest
{
    [ProtoMember(1)]
    public string Id { get; set; } = string.Empty;
}

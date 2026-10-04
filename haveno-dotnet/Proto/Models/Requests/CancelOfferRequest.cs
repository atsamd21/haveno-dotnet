using ProtoBuf;

namespace Haveno.Proto.Models.Requests;

[ProtoContract(Name = "CancelOfferRequest")]
internal class CancelOfferRequest
{
    [ProtoMember(1)]
    public string Id { get; set; } = string.Empty;
}

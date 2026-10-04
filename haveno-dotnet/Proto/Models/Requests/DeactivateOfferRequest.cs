using ProtoBuf;

namespace Haveno.Proto.Models.Requests;

[ProtoContract(Name = "DeactivateOfferRequest")]
internal class DeactivateOfferRequest
{
    [ProtoMember(1)]
    public string OfferId { get; set; } = string.Empty;
}

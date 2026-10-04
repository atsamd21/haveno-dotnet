using ProtoBuf;

namespace Haveno.Proto.Models.Requests;

[ProtoContract(Name = "ActivateOfferRequest")]
internal class ActivateOfferRequest
{
    [ProtoMember(1)]
    public string OfferId { get; set; } = string.Empty;
}

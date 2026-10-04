using ProtoBuf;

namespace Haveno.Proto.Models.Requests;

[ProtoContract(Name = "GetOffersRequest")]
internal class GetOffersRequest
{
    [ProtoMember(1)]
    public string Direction { get; set; } = string.Empty;
    [ProtoMember(2)]
    public string CurrencyCode { get; set; } = string.Empty;
}

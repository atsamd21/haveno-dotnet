using ProtoBuf;

namespace Haveno.Proto.Models.Requests;

[ProtoContract(Name = "GetBalancesRequest")]
internal class GetBalancesRequest
{
    [ProtoMember(1)]
    public string CurrencyCode { get; set; } = string.Empty;
}

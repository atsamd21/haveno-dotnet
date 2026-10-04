using ProtoBuf;

namespace Haveno.Proto.Models.Requests;

[ProtoContract(Name = "MarketDepthRequest")]
internal class MarketDepthRequest
{
    [ProtoMember(1)]
    public string CurrencyCode { get; set; } = string.Empty;
}

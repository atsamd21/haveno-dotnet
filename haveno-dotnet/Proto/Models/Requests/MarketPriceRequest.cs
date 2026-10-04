using ProtoBuf;

namespace Haveno.Proto.Models.Requests;

[ProtoContract(Name = "MarketPriceRequest")]
internal class MarketPriceRequest
{
    [ProtoMember(1)]
    public string CurrencyCode { get; set; } = string.Empty;
}

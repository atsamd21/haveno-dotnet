using ProtoBuf;

namespace Haveno.Proto.Models;

[ProtoContract(Name = "MarketPriceInfo")]
internal class MarketPriceInfo
{
    [ProtoMember(1)]
    public string CurrencyCode { get; set; } = string.Empty;
    [ProtoMember(2)]
    public double Price { get; set; }
}

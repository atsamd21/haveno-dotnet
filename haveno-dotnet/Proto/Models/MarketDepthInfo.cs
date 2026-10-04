using ProtoBuf;

namespace Haveno.Proto.Models;

[ProtoContract(Name = "MarketDepthInfo")]
internal class MarketDepthInfo
{
    [ProtoMember(1)]
    public string CurrencyCode { get; set; } = string.Empty;
    [ProtoMember(2)]
    public List<double> BuyPrices { get; set; } = [];
    [ProtoMember(3)]
    public List<double> BuyDepth { get; set; } = [];
    [ProtoMember(4)]
    public List<double> SellPrices { get; set; } = [];
    [ProtoMember(5)]
    public List<double> SellDepth { get; set; } = [];
}

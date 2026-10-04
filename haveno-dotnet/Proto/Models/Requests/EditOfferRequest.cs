using ProtoBuf;

namespace Haveno.Proto.Models.Requests;

[ProtoContract(Name = "EditOfferRequest")]
internal class EditOfferRequest
{
    [ProtoMember(1)]
    public string OfferId { get; set; } = string.Empty;
    [ProtoMember(2)]
    public string CurrencyCode { get; set; } = string.Empty;
    [ProtoMember(3)]
    public string Price { get; set; } = string.Empty;
    [ProtoMember(4)]
    public bool UseMarketBasedPrice { get; set; }
    [ProtoMember(5)]
    public double MarketPriceMarginPct { get; set; }
    [ProtoMember(6)]
    public string TriggerPrice { get; set; } = string.Empty;
    [ProtoMember(7)]
    public string PaymentAccountId { get; set; } = string.Empty;
    [ProtoMember(8)]
    public string ExtraInfo { get; set; } = string.Empty;
}

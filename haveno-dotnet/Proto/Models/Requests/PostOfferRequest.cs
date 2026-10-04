using ProtoBuf;

namespace Haveno.Proto.Models.Requests;

[ProtoContract(Name = "PostOfferRequest")]
internal class PostOfferRequest
{
    [ProtoMember(1)]
    public string CurrencyCode { get; set; } = string.Empty;
    [ProtoMember(2)]
    public string Direction { get; set; } = string.Empty;
    [ProtoMember(3)]
    public string Price { get; set; } = string.Empty;
    [ProtoMember(4)]
    public bool UseMarketBasedPrice { get; set; }
    [ProtoMember(5)]
    public double MarketPriceMarginPct { get; set; }
    [ProtoMember(6)]
    public ulong Amount { get; set; }
    [ProtoMember(7)]
    public ulong MinAmount { get; set; }
    [ProtoMember(8)]
    public double SecurityDepositPct { get; set; }
    [ProtoMember(9)]
    public string TriggerPrice { get; set; } = string.Empty;
    [ProtoMember(10)]
    public bool ReserveExactAmount { get; set; }
    [ProtoMember(11)]
    public string PaymentAccountId { get; set; } = string.Empty;
    [ProtoMember(12)]
    public bool IsPrivateOffer { get; set; }
    [ProtoMember(13)]
    public bool BuyerAsTakerWithoutDeposit { get; set; }
    [ProtoMember(14)]
    public string ExtraInfo { get; set; } = string.Empty;
    [ProtoMember(15)]
    public string SourceOfferId { get; set; } = string.Empty;
}

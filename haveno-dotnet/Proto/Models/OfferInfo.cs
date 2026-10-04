using ProtoBuf;

namespace Haveno.Proto.Models;

[ProtoContract(Name = "OfferInfo")]
internal class OfferInfo
{
    [ProtoMember(1)]
    public string Id { get; set; } = string.Empty;
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
    public double MakerFeePct { get; set; }
    [ProtoMember(9)]
    public double TakerFeePct { get; set; }
    [ProtoMember(10)]
    public double PenaltyFeePct { get; set; }
    [ProtoMember(11)]
    public double BuyerSecurityDepositPct { get; set; }
    [ProtoMember(12)]
    public double SellerSecurityDepositPct { get; set; }
    [ProtoMember(13)]
    public string Volume { get; set; } = string.Empty;
    [ProtoMember(14)]
    public string MinVolume { get; set; } = string.Empty;
    [ProtoMember(15)]
    public string TriggerPrice { get; set; } = string.Empty;
    [ProtoMember(16)]
    public string PaymentAccountId { get; set; } = string.Empty;
    [ProtoMember(17)]
    public string PaymentMethodId { get; set; } = string.Empty;
    [ProtoMember(18)]
    public string PaymentMethodShortName { get; set; } = string.Empty;
    [ProtoMember(19)]
    public string BaseCurrencyCode { get; set; } = string.Empty;
    [ProtoMember(20)]
    public string CounterCurrencyCode { get; set; } = string.Empty;
    [ProtoMember(21)]
    public ulong Date { get; set; }
    [ProtoMember(22)]
    public string State { get; set; } = string.Empty;
    [ProtoMember(23)]
    public bool IsActivated { get; set; }
    [ProtoMember(24)]
    public bool IsMyOffer { get; set; }
    [ProtoMember(25)]
    public string OwnerNodeAddress { get; set; } = string.Empty;
    [ProtoMember(26)]
    public string PubKeyRing { get; set; } = string.Empty;
    [ProtoMember(27)]
    public string VersionNr { get; set; } = string.Empty;
    [ProtoMember(28)]
    public int ProtocolVersion { get; set; }
    [ProtoMember(29)]
    public string ArbitratorSigner { get; set; } = string.Empty;
    [ProtoMember(30)]
    public string SplitOutputTxHash { get; set; } = string.Empty;
    [ProtoMember(31)]
    public ulong SplitOutputTxFee { get; set; }
    [ProtoMember(32)]
    public bool IsPrivateOffer { get; set; }
    [ProtoMember(33)]
    public string Challenge { get; set; } = string.Empty;   
    [ProtoMember(34)]
    public string ExtraInfo { get; set; } = string.Empty;
    [ProtoMember(35)]
    public List<string> AcceptedCountryCodes { get; set; } = [];
    [ProtoMember(36)]
    public string AcceptedCountriesString { get; set; } = string.Empty;
    [ProtoMember(37)]
    public string City { get; set; } = string.Empty;
}

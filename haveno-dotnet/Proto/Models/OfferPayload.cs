using Haveno.Shared.Enums;
using ProtoBuf;

namespace Haveno.Proto.Models;

[ProtoContract(Name = "OfferPayload")]
internal class OfferPayload
{
    [ProtoMember(1)]
    public string Id { get; set; } = string.Empty;
    [ProtoMember(2)]
    public long Date { get; set; }
    [ProtoMember(3)]
    public NodeAddress OwnerNodeAddress { get; set; } = new();
    [ProtoMember(4)]
    public PubKeyRing PubKeyRing { get; set; } = new();
    [ProtoMember(5)]
    public OfferDirection Direction { get; set; }
    [ProtoMember(6)]
    public long Price { get; set; }
    [ProtoMember(7)]
    public double MarketPriceMarginPct { get; set; }
    [ProtoMember(8)]
    public bool UseMarketBasedPrice { get; set; }
    [ProtoMember(9)]
    public long Amount { get; set; }
    [ProtoMember(10)]
    public long MinAmount { get; set; }
    [ProtoMember(11)]
    public double MakerFeePct { get; set; }
    [ProtoMember(12)]
    public double TakerFeePct { get; set; }
    [ProtoMember(13)]
    public double PenaltyFeePct { get; set; }
    [ProtoMember(14)]
    public double BuyerSecurityDepositPct { get; set; }
    [ProtoMember(15)]
    public double SellerSecurityDepositPct { get; set; }
    [ProtoMember(16)]
    public string BaseCurrencyCode { get; set; } = string.Empty;
    [ProtoMember(17)]
    public string CounterCurrencyCode { get; set; } = string.Empty;
    [ProtoMember(18)]
    public string PaymentMethodId { get; set; } = string.Empty;
    [ProtoMember(19)]
    public string MakerPaymentAccountId { get; set; } = string.Empty;
    [ProtoMember(20)]
    public string CountryCode { get; set; } = string.Empty;
    [ProtoMember(21)]
    public List<string> AcceptedCountryCodes { get; set; } = [];
    [ProtoMember(22)]
    public string BankId { get; set; } = string.Empty;
    [ProtoMember(23)]
    public List<string> AcceptedBankIds { get; set; } = [];
    [ProtoMember(24)]
    public string VersionNr { get; set; } = string.Empty;
    [ProtoMember(25)]
    public long BlockHeightAtOfferCreation { get; set; }
    [ProtoMember(26)]
    public long MaxTradeLimit { get; set; }
    [ProtoMember(27)]
    public long MaxTradePeriod { get; set; }
    [ProtoMember(28)]
    public bool UseAutoClose { get; set; }
    [ProtoMember(29)]
    public bool UseReOpenAfterAutoClose { get; set; }
    [ProtoMember(30)]
    public long LowerClosePrice { get; set; }
    [ProtoMember(31)]
    public long UpperClosePrice { get; set; }
    [ProtoMember(32)]
    public bool IsPrivateOffer { get; set; }
    [ProtoMember(33)]
    public string ChallengeHash { get; set; } = string.Empty;
    [ProtoMember(34)]
    public Dictionary<string, string> ExtraData { get; set; } = [];
    [ProtoMember(35)]
    public int ProtocolVersion { get; set; }
    [ProtoMember(36)]
    public NodeAddress ArbitratorSigner { get; set; } = new();
    [ProtoMember(37)]
    public byte[] ArbitratorSignature { get; set; } = [];
    [ProtoMember(38)]
    public List<string> ReserveTxKeyImages { get; set; } = [];
    [ProtoMember(39)]
    public string ExtraInfo { get; set; } = string.Empty;
}

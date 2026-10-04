namespace Haveno.Api.Models;

public class OfferPayload
{
    public string Id { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public NodeAddress OwnerNodeAddress { get; set; } = new();
    public PubKeyRing PubKeyRing { get; set; } = new();
    public Shared.Enums.OfferDirection Direction { get; set; }
    public long Price { get; set; }
    public double MarketPriceMarginPercent { get; set; }
    public bool UseMarketBasedPrice { get; set; }
    public long Amount { get; set; }
    public long MinAmount { get; set; }
    public double MakerFeePercent { get; set; }
    public double TakerFeePercent { get; set; }
    public double PenaltyFeePercent { get; set; }
    public double BuyerSecurityDepositPercent { get; set; }
    public double SellerSecurityDepositPercent { get; set; }
    public string BaseCurrencyCode { get; set; } = string.Empty;
    public string CounterCurrencyCode { get; set; } = string.Empty;
    public string PaymentMethodId { get; set; } = string.Empty;
    public string MakerPaymentAccountId { get; set; } = string.Empty;
    public string CountryCode { get; set; } = string.Empty;
    public List<string> AcceptedCountryCodes { get; set; } = [];
    public string BankId { get; set; } = string.Empty;
    public List<string> AcceptedBankIds { get; set; } = [];
    public string VersionNr { get; set; } = string.Empty;
    public long BlockHeightAtOfferCreation { get; set; }
    public long MaxTradeLimit { get; set; }
    public long MaxTradePeriod { get; set; }
    public bool UseAutoClose { get; set; }
    public bool UseReOpenAfterAutoClose { get; set; }
    public long LowerClosePrice { get; set; }
    public long UpperClosePrice { get; set; }
    public bool IsPrivateOffer { get; set; }
    public string ChallengeHash { get; set; } = string.Empty;
    public Dictionary<string, string> ExtraData { get; set; } = [];
    public int ProtocolVersion { get; set; }
    public NodeAddress ArbitratorSigner { get; set; } = new();
    public byte[] ArbitratorSignature { get; set; } = [];
    public List<string> ReserveTxKeyImages { get; set; } = [];
    public string ExtraInfo { get; set; } = string.Empty;
}

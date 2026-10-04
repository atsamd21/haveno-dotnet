namespace Haveno.Api.Models;

public enum OfferDirection
{
    ANY,
    BUY,
    SELL
}

public static class OfferDirectionExtensions
{
    public static string ToHavenoString(this OfferDirection direction)
    {
        return direction switch
        {
            OfferDirection.BUY => "BUY",
            OfferDirection.SELL => "SELL",
            OfferDirection.ANY => "",
            _ => throw new Exception(),
        };
    }
}

public enum OfferState
{
    //UNKNOWN,
    //PENDING,
    //AVAILABLE,
    //RESERVED,
    //CLOSED,
    //CANCELED,
    //DEACTIVATED
    PB_ERROR = 0,
    UNKNOWN = 1,
    OFFER_FEE_RESERVED = 2,
    AVAILABLE = 3,
    NOT_AVAILABLE = 4,
    REMOVED = 5,
    MAKER_OFFLINE = 6,
    INVALID = 7
}

public class OfferInfo
{
    public string Id { get; set; } = string.Empty;
    public OfferDirection Direction { get; set; }
    public decimal Price { get; set; }
    public double MarketPriceMarginPercent { get; set; }
    public ulong Amount { get; set; }
    public ulong MinAmount { get; set; }
    public double MakerFeePercent { get; set; }
    public double TakerFeePercent { get; set; }
    public double PenaltyFeePercent { get; set; }
    public double BuyerSecurityDepositPercent { get; set; }
    public double SellerSecurityDepositPercent { get; set; }
    public decimal FiatVolume { get; set; }
    public decimal FiatMinVolume { get; set; }
    public decimal TriggerPrice { get; set; }
    public string PaymentAccountId { get; set; } = string.Empty;
    public PaymentMethodId PaymentMethodId { get; set; }
    public string PaymentMethodShortName { get; set; } = string.Empty;
    // Always "XMR"
    public string BaseCurrencyCode { get; set; } = string.Empty;
    // Enum?
    public string CounterCurrencyCode { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public OfferState State { get; set; }
    public bool UseMarketBasedPrice { get; set; }
    public bool IsActivated { get; set; }
    public bool IsMyOffer { get; set; }
    public bool IsPrivateOffer { get; set; }
    public string OwnerNodeAddress { get; set; } = string.Empty;
    public string PubKeyRing { get; set; } = string.Empty;
    public string VersionNr { get; set; } = string.Empty;
    public int ProtocolVersion { get; set; }
    public string ArbitratorSigner { get; set; } = string.Empty;
    public string SplitOutputTxHash { get; set; } = string.Empty;
    public ulong SplitOutputTxFee { get; set; }
    public string Challenge { get; set; } = string.Empty;
    public string ExtraInfo { get; set; } = string.Empty;
    public List<string> AcceptedCountryCodes { get; set; } = [];
    public string AcceptedCountriesString { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
}

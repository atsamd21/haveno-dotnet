namespace Haveno.Api.Models.Requests;

public class PostOfferRequest
{
    public string CurrencyCode { get; set; } = string.Empty;
    public OfferDirection Direction { get; set; }
    public decimal Price { get; set; }
    public decimal TriggerPrice { get; set; }
    public double MarketPriceMarginPercent { get; set; }
    public double SecurityDepositPercent { get; set; }
    public ulong Amount { get; set; }
    public ulong MinAmount { get; set; }
    public string PaymentAccountId { get; set; } = string.Empty;
    public bool IsPrivateOffer { get; set; }
    public bool IsNoDepositOffer { get; set; }
    public bool UseMarketBasedPrice { get; set; }
    public bool ReserveExactAmount { get; set; }
    public string ExtraInfo { get; set; } = string.Empty;
    public string SourceOfferId { get; set; } = string.Empty;
}

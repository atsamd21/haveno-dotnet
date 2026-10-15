namespace Haveno.Api.Models.Requests;

public class EditOfferRequest
{
    public string OfferId { get; set; } = string.Empty;
    // 
    public string CurrencyCode { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public bool UseMarketBasedPrice { get; set; }
    public double MarketPriceMarginPercent { get; set; }
    public decimal TriggerPrice { get; set; }
    public string PaymentAccountId { get; set; } = string.Empty;
    public string ExtraInfo { get; set; } = string.Empty;
}

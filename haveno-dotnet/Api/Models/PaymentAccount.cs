namespace Haveno.Api.Models;

public class PaymentAccount
{
    public string Id { get; set; } = string.Empty;
    public string AccountName { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public PaymentMethod PaymentMethod { get; set; } = new();
    public List<TradeCurrency> TradeCurrencies { get; set; } = [];
    public TradeCurrency SelectedTradeCurrency { get; set; } = new();
    public PaymentAccountPayload PaymentAccountPayload { get; set; } = new();
}

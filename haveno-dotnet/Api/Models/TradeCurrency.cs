namespace Haveno.Api.Models;

public class TradeCurrency
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public CryptoCurrency? CryptoCurrency { get; set; }
    public TraditionalCurrency? TraditionalCurrency { get; set; }
}

namespace Haveno.Api.Models;

public class PaymentMethod
{
    public PaymentMethodId Id { get; set; }
    public TimeSpan MaxTradePeriod { get; set; }
    public ulong MaxTradeLimit { get; set; }
    public List<string> SupportedAssetCodes { get; set; } = [];
}

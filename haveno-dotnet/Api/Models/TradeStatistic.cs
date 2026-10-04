namespace Haveno.Api.Models;

public class TradeStatistic
{
    public string Currency { get; set; } = string.Empty;
    public ulong Price { get; set; }
    public ulong Amount { get; set; }
    public string PaymentMethod { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public string Arbitrator { get; set; } = string.Empty;
    public byte[] Hash { get; set; } = [];
    public string MakerDepositTxId { get; set; } = string.Empty;
    public string TakerDepositTxId { get; set; } = string.Empty;
    public Dictionary<string, string> ExtraData { get; set; } = [];
}

namespace Haveno.Api.Models;

public class XmrBalanceInfo
{
    public ulong Balance { get; set; }
    public ulong AvailableBalance { get; set; }
    public ulong PendingBalance { get; set; }
    public ulong ReservedOfferBalance { get; set; }
    public ulong ReservedTradeBalance { get; set; }
}

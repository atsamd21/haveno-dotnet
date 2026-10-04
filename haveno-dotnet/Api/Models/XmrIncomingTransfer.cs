namespace Haveno.Api.Models;

public class XmrIncomingTransfer
{
    public ulong Amount { get; set; }
    public int AccountIndex { get; set; }
    public int SubaddressIndex { get; set; }
    public string Address { get; set; } = string.Empty;
    public ulong NumSuggestedConfirmations { get; set; }
}

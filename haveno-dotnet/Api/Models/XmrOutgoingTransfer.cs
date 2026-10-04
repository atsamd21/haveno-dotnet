namespace Haveno.Api.Models;

public class XmrOutgoingTransfer
{
    public ulong Amount { get; set; }
    public int AccountIndex { get; set; }
    public List<int> SubaddressIndices { get; set; } = [];
    public List<XmrDestination> Destinations { get; set; } = [];
}

using Haveno.Shared.Enums;

namespace Haveno.Api.Models.Requests;

public class ResolveDisputeRequest
{
    public string TradeId { get; set; } = string.Empty;
    public WinnerType Winner { get; set; }
    public ReasonType Reason { get; set; }
    public string SummaryNotes { get; set; } = string.Empty;
    public long CustomPayoutAmount { get; set; }
}

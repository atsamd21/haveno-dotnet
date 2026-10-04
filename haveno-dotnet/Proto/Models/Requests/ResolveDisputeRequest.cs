using Haveno.Shared.Enums;
using ProtoBuf;

namespace Haveno.Proto.Models.Requests;

[ProtoContract(Name = "ResolveDisputeRequest")]
internal class ResolveDisputeRequest
{
    [ProtoMember(1)]
    public string TradeId { get; set; } = string.Empty;
    [ProtoMember(2)]
    public WinnerType Winner { get; set; }
    [ProtoMember(3)]
    public ReasonType Reason { get; set; }
    [ProtoMember(4)]
    public string SummaryNotes { get; set; } = string.Empty;
    [ProtoMember(5)]
    public long CustomPayoutAmount { get; set; }
}

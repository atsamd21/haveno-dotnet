using Haveno.Shared.Enums;
using ProtoBuf;

namespace Haveno.Proto.Models;

[ProtoContract(Name = "DisputeResult")]
internal class DisputeResult
{
    [ProtoMember(1)]
    public string TradeId { get; set; } = string.Empty;
    [ProtoMember(2)]
    public int TraderId { get; set; }
    [ProtoMember(3)]
    public WinnerType Winner { get; set; }
    [ProtoMember(4)]
    public int ReasonOrdinal { get; set; }
    [ProtoMember(5)]
    public bool TamperProofEvidence { get; set; }
    [ProtoMember(6)]
    public bool IdVerification { get; set; }
    [ProtoMember(7)]
    public bool ScreenCast { get; set; }
    [ProtoMember(8)]
    public string SummaryNotes { get; set; } = string.Empty;
    [ProtoMember(9)]
    public ChatMessage ChatMessage { get; set; } = new();
    [ProtoMember(10)]
    public byte[] ArbitratorSignature { get; set; } = [];
    [ProtoMember(11)]
    public long BuyerPayoutAmountBeforeCost { get; set; }
    [ProtoMember(12)]
    public long SellerPayoutAmountBeforeCost { get; set; }
    [ProtoMember(13)]
    public SubtractFeeFromType SubtractFeeFrom { get; set; }
    [ProtoMember(14)]
    public byte[] ArbitratorPubKey { get; set; } = [];
    [ProtoMember(15)]
    public long CloseDate { get; set; }
    [ProtoMember(16)]
    public bool IsLoserPublisher { get; set; }
}

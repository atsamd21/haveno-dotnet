using Haveno.Shared.Enums;
using ProtoBuf;

namespace Haveno.Proto.Models;

[ProtoContract(Name = "Dispute")]
internal class Dispute
{
    [ProtoMember(1)]
    public string TradeId { get; set; } = string.Empty;
    [ProtoMember(2)]
    public string Id { get; set; } = string.Empty;
    [ProtoMember(3)]
    public int TraderId { get; set; }
    [ProtoMember(4)]
    public bool IsOpener { get; set; }
    [ProtoMember(5)]
    public bool DisputeOpenerIsBuyer { get; set; }
    [ProtoMember(6)]
    public bool DisputeOpenerIsMaker { get; set; }
    [ProtoMember(7)]
    public long OpeningDate { get; set; }
    [ProtoMember(8)]
    public PubKeyRing TraderPubKeyRing { get; set; } = new();
    [ProtoMember(9)]
    public long TradeDate { get; set; }
    [ProtoMember(10)]
    public Contract Contract { get; set; } = new();
    [ProtoMember(11)]
    public byte[] ContractHash { get; set; } = [];
    [ProtoMember(12)]
    public byte[] PayoutTxSerialized { get; set; } = [];
    [ProtoMember(13)]
    public string PayoutTxId { get; set; } = string.Empty;
    [ProtoMember(14)]
    public string ContractAsJson { get; set; } = string.Empty;
    [ProtoMember(15)]
    public byte[] MakerContractSignature { get; set; } = [];
    [ProtoMember(16)]
    public byte[] TakerContractSignature { get; set; } = [];
    [ProtoMember(17)]
    public PaymentAccountPayload? MakerPaymentAccountPayload { get; set; }
    [ProtoMember(18)]
    public PaymentAccountPayload? TakerPaymentAccountPayload { get; set; }
    [ProtoMember(19)]
    public PubKeyRing AgentPubKeyRing { get; set; } = new();
    [ProtoMember(20)]
    public bool IsSupportTicket { get; set; }
    [ProtoMember(21)]
    public List<ChatMessage> ChatMessage { get; set; } = [];
    [ProtoMember(22)]
    public bool IsClosed { get; set; }
    [ProtoMember(23)]
    public DisputeResult DisputeResult { get; set; } = new();
    [ProtoMember(24)]
    public string DisputePayoutTxId { get; set; } = string.Empty;
    [ProtoMember(25)]
    public SupportType SupportType { get; set; }
    [ProtoMember(26)]
    public string MediatorsDisputeResult { get; set; } = string.Empty;
    [ProtoMember(27)]
    public string DelayedPayoutTxId { get; set; } = string.Empty;
    [ProtoMember(28)]
    public string DonationAddressOfDelayedPayoutTx { get; set; } = string.Empty;
    [ProtoMember(29)]
    public DisputeState State { get; set; }
    [ProtoMember(30)]
    public long TradePeriodEnd { get; set; }
    [ProtoMember(31)]
    public Dictionary<string, string> ExtraData { get; set; } = [];
}

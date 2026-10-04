using Haveno.Shared.Enums;

namespace Haveno.Api.Models;

public class Dispute
{
    public string TradeId { get; set; } = string.Empty;
    public string Id { get; set; } = string.Empty;
    public int TraderId { get; set; }
    public bool IsOpener { get; set; }
    public bool IsSupportTicket { get; set; }
    public bool IsClosed { get; set; }
    public bool DisputeOpenerIsBuyer { get; set; }
    public bool DisputeOpenerIsMaker { get; set; }
    public DateTime OpeningDate { get; set; }
    public PubKeyRing TraderPubKeyRing { get; set; } = new();
    public DateTime TradeDate { get; set; }
    public Contract Contract { get; set; } = new();
    public byte[] ContractHash { get; set; } = [];
    public byte[] PayoutTxSerialized { get; set; } = [];
    public string PayoutTxId { get; set; } = string.Empty;
    public string ContractAsJson { get; set; } = string.Empty;
    public byte[] MakerContractSignature { get; set; } = [];
    public byte[] TakerContractSignature { get; set; } = [];
    public PaymentAccountPayload? MakerPaymentAccountPayload { get; set; }
    public PaymentAccountPayload? TakerPaymentAccountPayload { get; set; }
    public PubKeyRing AgentPubKeyRing { get; set; } = new();
    public List<ChatMessage> ChatMessages { get; set; } = [];
    public DisputeResult DisputeResult { get; set; } = new();
    public string DisputePayoutTxId { get; set; } = string.Empty;
    public SupportType SupportType { get; set; }
    public string MediatorsDisputeResult { get; set; } = string.Empty;
    public string DelayedPayoutTxId { get; set; } = string.Empty;
    public string DonationAddressOfDelayedPayoutTx { get; set; } = string.Empty;
    public DisputeState State { get; set; }
    public DateTime TradePeriodEnd { get; set; }
    public Dictionary<string, string> ExtraData { get; set; } = [];
}

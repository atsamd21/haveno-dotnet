using ProtoBuf;

namespace Haveno.Proto.Models;

[ProtoContract(Name = "TradeInfo")]
internal class TradeInfo
{
    [ProtoMember(1)]
    public OfferInfo Offer { get; set; } = new();
    [ProtoMember(2)]
    public string TradeId { get; set; } = string.Empty;
    [ProtoMember(3)]
    public string ShortId { get; set; } = string.Empty;
    [ProtoMember(4)]
    public ulong Date { get; set; }
    [ProtoMember(5)]
    public string Role { get; set; } = string.Empty;
    [ProtoMember(6)]
    public ulong Amount { get; set; }
    [ProtoMember(7)]
    public ulong MakerFee { get; set; }
    [ProtoMember(8)]
    public ulong TakerFee { get; set; }
    [ProtoMember(9)]
    public ulong BuyerSecurityDeposit { get; set; }
    [ProtoMember(10)]
    public ulong SellerSecurityDeposit { get; set; }
    [ProtoMember(11)]
    public ulong BuyerDepositTxFee { get; set; }
    [ProtoMember(12)]
    public ulong SellerDepositTxFee { get; set; }
    [ProtoMember(13)]
    public ulong BuyerPayoutTxFee { get; set; }
    [ProtoMember(14)]
    public ulong SellerPayoutTxFee { get; set; }
    [ProtoMember(15)]
    public ulong BuyerPayoutAmount { get; set; }
    [ProtoMember(16)]
    public ulong SellerPayoutAmount { get; set; }
    [ProtoMember(17)]
    public string Price { get; set; } = string.Empty;
    [ProtoMember(18)]
    public string ArbitratorNodeAddress { get; set; } = string.Empty;
    [ProtoMember(19)]
    public string TradePeerNodeAddress { get; set; } = string.Empty;
    [ProtoMember(20)]
    public string State { get; set; } = string.Empty;
    [ProtoMember(21)]
    public string Phase { get; set; } = string.Empty;
    [ProtoMember(22)]
    public string PeriodState { get; set; } = string.Empty;
    [ProtoMember(23)]
    public string PayoutState { get; set; } = string.Empty;
    [ProtoMember(24)]
    public string DisputeState { get; set; } = string.Empty;
    [ProtoMember(25)]
    public bool IsDepositsPublished { get; set; }
    [ProtoMember(26)]
    public bool IsDepositsConfirmed { get; set; }
    [ProtoMember(27)]
    public bool IsDepositsUnlocked { get; set; }
    [ProtoMember(43)]
    public bool IsDepositsFinalized { get; set; }
    [ProtoMember(28)]
    public bool IsPaymentSent { get; set; }
    [ProtoMember(29)]
    public bool IsPaymentReceived { get; set; }
    [ProtoMember(30)]
    public bool IsPayoutPublished { get; set; }
    [ProtoMember(31)]
    public bool IsPayoutConfirmed { get; set; }
    [ProtoMember(32)]
    public bool IsPayoutUnlocked { get; set; }
    [ProtoMember(44)]
    public bool IsPayoutFinalized { get; set; }
    [ProtoMember(33)]
    public bool IsCompleted { get; set; }
    [ProtoMember(34)]
    public string ContractAsJson { get; set; } = string.Empty;
    [ProtoMember(35)]
    public ContractInfo Contract { get; set; } = new();
    [ProtoMember(36)]
    public string TradeVolume { get; set; } = string.Empty;
    [ProtoMember(37)]
    public string MakerDepositTxId { get; set; } = string.Empty;
    [ProtoMember(38)]
    public string TakerDepositTxId { get; set; } = string.Empty;
    [ProtoMember(39)]
    public string PayoutTxId { get; set; } = string.Empty;
    [ProtoMember(40)]
    public ulong StartTime { get; set; }
    [ProtoMember(41)]
    public ulong MaxDurationMs { get; set; }
    [ProtoMember(42)]
    public ulong DeadlineTime { get; set; }
}

using ProtoBuf;

namespace Haveno.Proto.Models;

[ProtoContract(Name = "TradeStatistics3")]
internal class TradeStatistics3
{
    [ProtoMember(1)]
    public string Currency { get; set; } = string.Empty;
    [ProtoMember(2)]
    public long Price { get; set; }
    [ProtoMember(3)]
    public long Amount { get; set; }
    [ProtoMember(4)]
    public string PaymentMethod { get; set; } = string.Empty;
    [ProtoMember(5)]
    public long Date { get; set; }
    [ProtoMember(6)]
    public string Arbitrator { get; set; } = string.Empty;
    [ProtoMember(7)]
    public byte[] Hash { get; set; } = [];
    [ProtoMember(8)]
    public string MakerDepositTxId { get; set; } = string.Empty;
    [ProtoMember(9)]
    public string TakerDepositTxId { get; set; } = string.Empty;
    [ProtoMember(10)]
    public Dictionary<string, string> ExtraData { get; set; } = [];
}

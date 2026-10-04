using ProtoBuf;

namespace Haveno.Proto.Models;

[ProtoContract(Name = "ContractInfo")]
internal class ContractInfo
{
    [ProtoMember(1)]
    public string BuyerNodeAddress { get; set; } = string.Empty;
    [ProtoMember(2)]
    public string SellerNodeAddress { get; set; } = string.Empty;
    [ProtoMember(3)]
    public string ArbitratorNodeAddress { get; set; } = string.Empty;
    [ProtoMember(6)]
    public bool IsBuyerMakerAndSellerTaker { get; set; }
    [ProtoMember(7)]
    public string MakerAccountId { get; set; } = string.Empty;
    [ProtoMember(8)]
    public string TakerAccountId { get; set; } = string.Empty;
    [ProtoMember(9)]
    public PaymentAccountPayload? MakerPaymentAccountPayload { get; set; }
    [ProtoMember(10)]
    public PaymentAccountPayload? TakerPaymentAccountPayload { get; set; }
    [ProtoMember(11)]
    public string MakerPayoutAddressString { get; set; } = string.Empty;
    [ProtoMember(12)]
    public string TakerPayoutAddressString { get; set; } = string.Empty;
    [ProtoMember(13)]
    public ulong LockTime { get; set; }
}

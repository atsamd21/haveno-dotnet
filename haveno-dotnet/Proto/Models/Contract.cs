using ProtoBuf;

namespace Haveno.Proto.Models;

[ProtoContract(Name = "Contract")]
internal class Contract
{
    [ProtoMember(1)]
    public OfferPayload OfferPayload { get; set; } = new();
    [ProtoMember(2)]
    public long TradeAmount { get; set; }
    [ProtoMember(3)]
    public long TradePrice { get; set; }
    [ProtoMember(4)]
    public NodeAddress ArbitratorNodeAddress { get; set; } = new();
    [ProtoMember(5)]
    public bool IsBuyerMakerAndSellerTaker { get; set; }
    [ProtoMember(6)]
    public string MakerAccountId { get; set; } = string.Empty;
    [ProtoMember(7)]
    public string TakerAccountId { get; set; } = string.Empty;
    [ProtoMember(8)]
    public string MakerPaymentMethodId { get; set; } = string.Empty;
    [ProtoMember(9)]
    public string TakerPaymentMethodId { get; set; } = string.Empty;
    [ProtoMember(10)]
    public byte[] MakerPaymentAccountPayloadHash { get; set; } = [];
    [ProtoMember(11)]
    public byte[] TakerPaymentAccountPayloadHash { get; set; } = [];
    [ProtoMember(12)]
    public PubKeyRing MakerPubKeyRing { get; set; } = new();
    [ProtoMember(13)]
    public PubKeyRing TakerPubKeyRing { get; set; } = new();
    [ProtoMember(14)]
    public NodeAddress BuyerNodeAddress { get; set; } = new();
    [ProtoMember(15)]
    public NodeAddress SellerNodeAddress { get; set; } = new();
    [ProtoMember(16)]
    public string MakerPayoutAddressString { get; set; } = string.Empty;
    [ProtoMember(17)]
    public string TakerPayoutAddressString { get; set; } = string.Empty;
    [ProtoMember(18)]
    public string MakerDepositTxHash { get; set; } = string.Empty;
    [ProtoMember(19)]
    public string TakerDepositTxHash { get; set; } = string.Empty;
}

using ProtoBuf;

namespace Haveno.Proto.Models;

[ProtoContract(Name = "PaymentAccount")]
internal class PaymentAccount
{
    [ProtoMember(1)]
    public string Id { get; set; } = string.Empty;
    [ProtoMember(2)]
    public long CreationDate { get; set; }
    [ProtoMember(3)]
    public PaymentMethod PaymentMethod { get; set; } = new();
    [ProtoMember(4)]
    public string AccountName { get; set; } = string.Empty;
    [ProtoMember(5)]
    public List<TradeCurrency> TradeCurrencies { get; set; } = [];
    [ProtoMember(6)]
    public TradeCurrency SelectedTradeCurrency { get; set; } = new();
    [ProtoMember(7)]
    public PaymentAccountPayload PaymentAccountPayload { get; set; } = new();
}

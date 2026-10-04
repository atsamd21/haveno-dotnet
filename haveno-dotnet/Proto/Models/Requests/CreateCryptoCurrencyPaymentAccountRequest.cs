using ProtoBuf;

namespace Haveno.Proto.Models.Requests;

[ProtoContract(Name = "CreateCryptoCurrencyPaymentAccountRequest")]
internal class CreateCryptoCurrencyPaymentAccountRequest
{
    [ProtoMember(1)]
    public string AccountName { get; set; } = string.Empty;
    [ProtoMember(2)]
    public string CurrencyCode { get; set; } = string.Empty;
    [ProtoMember(3)]
    public string Address { get; set; } = string.Empty;
    [ProtoMember(4)]
    public bool TradeInstant { get; set; }
}

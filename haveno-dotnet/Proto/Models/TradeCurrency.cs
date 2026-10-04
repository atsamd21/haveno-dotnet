using ProtoBuf;

namespace Haveno.Proto.Models;

[ProtoContract(Name = "TradeCurrency")]
internal class TradeCurrency
{
    [ProtoMember(1)]
    public string Code { get; set; } = string.Empty;
    [ProtoMember(2)]
    public string Name { get; set; } = string.Empty;
    [ProtoMember(3)]
    public CryptoCurrency? CryptoCurrency { get; set; }
    [ProtoMember(4)]
    public TraditionalCurrency? TraditionalCurrency { get; set; }
}

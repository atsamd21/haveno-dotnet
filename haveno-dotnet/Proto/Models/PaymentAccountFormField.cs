using Haveno.Shared.Enums;
using ProtoBuf;

namespace Haveno.Proto.Models;

[ProtoContract(Name = "PaymentAccountFormField")]
internal class PaymentAccountFormField
{
    [ProtoMember(1)]
    public FieldId Id { get; set; }
    [ProtoMember(2)]
    public Component Component { get; set; }
    [ProtoMember(3)]
    public string Type { get; set; } = string.Empty;
    [ProtoMember(4)]
    public string Label { get; set; } = string.Empty;
    [ProtoMember(5)]
    public string Value { get; set; } = string.Empty;
    [ProtoMember(6)]
    public uint MinLength { get; set; }
    [ProtoMember(7)]
    public uint MaxLength { get; set; }
    [ProtoMember(8)]
    public List<TradeCurrency> SupportedCurrencies { get; set; } = [];
    [ProtoMember(9)]
    public List<Country> SupportedCountries { get; set; } = [];
    [ProtoMember(10)]
    public List<Country> SupportedSepaEuroCountries { get; set; } = [];
    [ProtoMember(11)]
    public List<Country> SupportedSepaNonEuroCountries { get; set; } = [];
    [ProtoMember(12)]
    public List<string> RequiredForCountries { get; set; } = [];
}

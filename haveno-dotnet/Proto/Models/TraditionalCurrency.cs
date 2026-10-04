using ProtoBuf;

namespace Haveno.Proto.Models;

[ProtoContract(Name = "TraditionalCurrency")]
internal class TraditionalCurrency
{
    [ProtoMember(1)]
    public string Placeholder { get; set; } = string.Empty;
}

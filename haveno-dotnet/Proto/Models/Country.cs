using ProtoBuf;

namespace Haveno.Proto.Models;

[ProtoContract(Name = "Country")]
internal class Country
{
    [ProtoMember(1)]
    public string Code { get; set; } = string.Empty;
    [ProtoMember(2)]
    public string Name { get; set; } = string.Empty;
    [ProtoMember(3)]
    public Region Region { get; set; } = new();
}

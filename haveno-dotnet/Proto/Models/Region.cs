using ProtoBuf;

namespace Haveno.Proto.Models;

[ProtoContract(Name = "Region")]
internal class Region
{
    [ProtoMember(1)]
    public string Code { get; set; } = string.Empty;
    [ProtoMember(2)]
    public string Name { get; set; } = string.Empty;
}

using ProtoBuf;

namespace Haveno.Proto.Models;

[ProtoContract(Name = "XmrDestination")]
internal class XmrDestination
{
    [ProtoMember(1)]
    public string Address { get; set; } = string.Empty;
    [ProtoMember(2)]
    public string Amount { get; set; } = string.Empty;
}

using ProtoBuf;

namespace Haveno.Proto.Models;

[ProtoContract(Name = "NodeAddress")]
internal class NodeAddress
{
    [ProtoMember(1)]
    public string HostName { get; set; } = string.Empty;   
    [ProtoMember(2)]
    public int Port { get; set; }
}

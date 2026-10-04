using ProtoBuf;

namespace Haveno.Proto.Models.Requests;

[ProtoContract(Name = "SetAutoSwitchRequest")]
internal class SetAutoSwitchRequest
{
    [ProtoMember(1)]
    public bool AutoSwitch { get; set; }
}

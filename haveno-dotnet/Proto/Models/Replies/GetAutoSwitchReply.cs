using ProtoBuf;

namespace Haveno.Proto.Models.Replies;

[ProtoContract(Name = "GetAutoSwitchReply")]
internal class GetAutoSwitchReply
{
    [ProtoMember(1)]
    public bool AutoSwitch { get; set; }
}

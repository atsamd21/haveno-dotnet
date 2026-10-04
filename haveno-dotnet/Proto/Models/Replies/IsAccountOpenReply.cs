using ProtoBuf;

namespace Haveno.Proto.Models.Replies;

[ProtoContract(Name = "IsAccountOpenReply")]
internal class IsAccountOpenReply
{
    [ProtoMember(1)]
    public bool IsAccountOpen { get; set; }
}

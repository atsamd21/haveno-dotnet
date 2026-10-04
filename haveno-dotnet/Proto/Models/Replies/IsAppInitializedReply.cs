using ProtoBuf;

namespace Haveno.Proto.Models.Replies;

[ProtoContract(Name = "IsAppInitializedReply")]
internal class IsAppInitializedReply
{
    [ProtoMember(1)]
    public bool IsAppInitialized { get; set; }
}

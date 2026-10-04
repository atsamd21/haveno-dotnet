using ProtoBuf;

namespace Haveno.Proto.Models.Replies;

[ProtoContract(Name = "GetVersionReply")]
internal class GetVersionReply
{
    [ProtoMember(1)]
    public string Version { get; set; } = string.Empty;
}

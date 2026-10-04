using ProtoBuf;

namespace Haveno.Proto.Models.Replies;

[ProtoContract(Name = "CheckConnectionReply")]
internal class CheckConnectionReply
{
    [ProtoMember(1)]
    public UrlConnection Connection { get; set; } = new();
}

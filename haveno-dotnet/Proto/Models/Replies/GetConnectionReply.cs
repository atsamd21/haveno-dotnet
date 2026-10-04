using ProtoBuf;

namespace Haveno.Proto.Models.Replies;

[ProtoContract(Name = "GetConnectionReply")]
internal class GetConnectionReply
{
    [ProtoMember(1)]
    public UrlConnection Connection { get; set; } = new();
}

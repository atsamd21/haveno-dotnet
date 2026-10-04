using ProtoBuf;

namespace Haveno.Proto.Models.Replies;

[ProtoContract(Name = "GetBestConnectionReply")]
internal class GetBestConnectionReply
{
    [ProtoMember(1)]
    public UrlConnection Connection { get; set; } = new();
}

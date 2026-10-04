using ProtoBuf;

namespace Haveno.Proto.Models.Replies;

[ProtoContract(Name = "GetConnectionsReply")]
internal class GetConnectionsReply
{
    [ProtoMember(1)]
    public List<UrlConnection> Connections { get; set; } = [];
}

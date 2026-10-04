using ProtoBuf;

namespace Haveno.Proto.Models.Replies;

[ProtoContract(Name = "CheckConnectionsReply")]
internal class CheckConnectionsReply
{
    public List<UrlConnection> Connections { get; set; } = [];
}

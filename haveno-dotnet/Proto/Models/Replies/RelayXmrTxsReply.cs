using ProtoBuf;

namespace Haveno.Proto.Models.Replies;

[ProtoContract(Name = "RelayXmrTxsReply")]
internal class RelayXmrTxsReply
{
    [ProtoMember(2)]
    public List<string> Hashes { get; set; } = [];
}
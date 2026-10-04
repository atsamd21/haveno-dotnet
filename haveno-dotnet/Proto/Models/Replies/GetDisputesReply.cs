using ProtoBuf;

namespace Haveno.Proto.Models.Replies;

[ProtoContract(Name = "GetDisputesReply")]
internal class GetDisputesReply
{
    [ProtoMember(1)]
    public List<Dispute> Disputes { get; set; } = [];
}

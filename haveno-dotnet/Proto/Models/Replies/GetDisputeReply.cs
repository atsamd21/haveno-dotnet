using ProtoBuf;

namespace Haveno.Proto.Models.Replies;

[ProtoContract(Name = "GetDisputeReply")]
internal class GetDisputeReply
{
    [ProtoMember(1)]
    public Dispute Dispute { get; set; } = new();
}

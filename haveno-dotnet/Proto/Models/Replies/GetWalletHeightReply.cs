using ProtoBuf;

namespace Haveno.Proto.Models.Replies;

[ProtoContract(Name = "GetWalletHeightReply")]
internal class GetWalletHeightReply
{
    [ProtoMember(1)]
    public long Height { get; set; }
    [ProtoMember(2)]
    public long TargetHeight { get; set; }
}

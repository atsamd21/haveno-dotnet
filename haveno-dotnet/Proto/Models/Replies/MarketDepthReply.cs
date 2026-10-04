using ProtoBuf;

namespace Haveno.Proto.Models.Replies;

[ProtoContract(Name = "MarketDepthReply")]
internal class MarketDepthReply
{
    [ProtoMember(1)]
    public MarketDepthInfo MarketDepth { get; set; } = new();
}

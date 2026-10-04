using ProtoBuf;

namespace Haveno.Proto.Models.Replies;

[ProtoContract(Name = "GetTradeReply")]
internal class GetTradeReply
{
    [ProtoMember(1)]
    public TradeInfo Trade { get; set; } = new();
}

using ProtoBuf;

namespace Haveno.Proto.Models.Replies;

[ProtoContract(Name = "GetTradesReply")]
internal class GetTradesReply
{
    [ProtoMember(1)]
    public List<TradeInfo> Trades { get; set; } = [];
}

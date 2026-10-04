using ProtoBuf;

namespace Haveno.Proto.Models.Replies;

[ProtoContract(Name = "GetTradeStatisticsReply")]
internal class GetTradeStatisticsReply
{
    [ProtoMember(1)]
    public List<TradeStatistics3> TradeStatistics3 { get; set; } = [];
}

using ProtoBuf;

namespace Haveno.Proto.Models.Replies;

[ProtoContract(Name = "MarketPricesReply")]
internal class MarketPricesReply
{
    [ProtoMember(1)]
    public List<MarketPriceInfo> MarketPrice { get; set; } = [];
}

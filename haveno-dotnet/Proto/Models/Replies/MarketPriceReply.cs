using ProtoBuf;

namespace Haveno.Proto.Models.Replies;

[ProtoContract(Name = "MarketPriceReply")]
internal class MarketPriceReply
{
    [ProtoMember(1)]
    public double Price { get; set; }
}

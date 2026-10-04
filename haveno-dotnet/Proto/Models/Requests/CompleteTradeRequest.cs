using ProtoBuf;

namespace Haveno.Proto.Models.Requests;

[ProtoContract(Name = "CompleteTradeRequest")]
internal class CompleteTradeRequest
{
    [ProtoMember(1)]
    public string TradeId { get; set; } = string.Empty;
}

using ProtoBuf;

namespace Haveno.Proto.Models.Requests;

[ProtoContract(Name = "GetTradeRequest")]
internal class GetTradeRequest
{
    [ProtoMember(1)]
    public string TradeId { get; set; } = string.Empty;
}

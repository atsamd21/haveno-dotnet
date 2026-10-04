using ProtoBuf;

namespace Haveno.Proto.Models.Requests;

[ProtoContract(Name = "GetDisputeRequest")]
internal class GetDisputeRequest
{
    [ProtoMember(1)]
    public string TradeId { get; set; } = string.Empty;
}

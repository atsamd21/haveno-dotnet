using ProtoBuf;

namespace Haveno.Proto.Models.Requests;

[ProtoContract(Name = "OpenDisputeRequest")]
internal class OpenDisputeRequest
{
    [ProtoMember(1)]
    public string TradeId { get; set; } = string.Empty;
}

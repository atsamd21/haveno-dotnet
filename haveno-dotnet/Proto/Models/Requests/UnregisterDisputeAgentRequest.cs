using ProtoBuf;

namespace Haveno.Proto.Models.Requests;

[ProtoContract(Name = "UnregisterDisputeAgentRequest")]
internal class UnregisterDisputeAgentRequest
{
    [ProtoMember(1)]
    public string DisputeAgentType { get; set; } = string.Empty;
}

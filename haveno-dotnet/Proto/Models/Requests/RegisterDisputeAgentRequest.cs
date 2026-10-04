using ProtoBuf;

namespace Haveno.Proto.Models.Requests;

[ProtoContract(Name = "RegisterDisputeAgentRequest")]
internal class RegisterDisputeAgentRequest
{
    [ProtoMember(1)]
    public string DisputeAgentType { get; set; } = string.Empty;
    [ProtoMember(2)]
    public string RegistrationKey { get; set; } = string.Empty;
}

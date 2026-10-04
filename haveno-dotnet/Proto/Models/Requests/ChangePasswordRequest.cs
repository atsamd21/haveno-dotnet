using ProtoBuf;

namespace Haveno.Proto.Models.Requests;

[ProtoContract(Name = "ChangePasswordRequest")]
internal class ChangePasswordRequest
{
    [ProtoMember(1)]
    public string OldPassword { get; set; } = string.Empty;
    [ProtoMember(2)]
    public string NewPassword { get; set; } = string.Empty;
}

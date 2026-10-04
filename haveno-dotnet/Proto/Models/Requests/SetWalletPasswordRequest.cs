using ProtoBuf;

namespace Haveno.Proto.Models.Requests;

[ProtoContract(Name = "SetWalletPasswordRequest")]
internal class SetWalletPasswordRequest
{
    [ProtoMember(1)]
    public string Password { get; set; } = string.Empty;
    [ProtoMember(2)]
    public string NewPassword { get; set; } = string.Empty;
}


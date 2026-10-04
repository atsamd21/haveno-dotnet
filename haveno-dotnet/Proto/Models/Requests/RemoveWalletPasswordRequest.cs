using ProtoBuf;

namespace Haveno.Proto.Models.Requests;

[ProtoContract(Name = "RemoveWalletPasswordRequest")]
internal class RemoveWalletPasswordRequest
{
    [ProtoMember(1)]
    public string Password { get; set; } = string.Empty;
}
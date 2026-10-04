using ProtoBuf;

namespace Haveno.Proto.Models.Requests;

[ProtoContract(Name = "UnlockWalletRequest")]
internal class UnlockWalletRequest
{
    [ProtoMember(1)]
    public string Password { get; set; } = string.Empty;
    [ProtoMember(2)]
    public long Timeout { get; set; }
}
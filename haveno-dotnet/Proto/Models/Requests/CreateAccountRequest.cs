using ProtoBuf;

namespace Haveno.Proto.Models.Requests;

[ProtoContract(Name = "CreateAccountRequest")]
internal class CreateAccountRequest
{
    [ProtoMember(1)]
    public string Password { get; set; } = string.Empty;
}

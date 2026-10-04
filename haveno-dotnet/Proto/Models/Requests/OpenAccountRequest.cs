using ProtoBuf;

namespace Haveno.Proto.Models.Requests;

[ProtoContract(Name = "OpenAccountRequest")]
internal class OpenAccountRequest
{
    [ProtoMember(1)]
    public string Password { get; set; } = string.Empty;
}

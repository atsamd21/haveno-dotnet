using ProtoBuf;

namespace Haveno.Proto.Models.Requests;

[ProtoContract(Name = "AddConnectionRequest")]
internal class AddConnectionRequest
{
    [ProtoMember(1)]
    public UrlConnection Connection { get; set; } = new();
}

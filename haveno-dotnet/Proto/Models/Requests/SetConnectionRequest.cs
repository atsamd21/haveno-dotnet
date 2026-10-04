using ProtoBuf;

namespace Haveno.Proto.Models.Requests;

[ProtoContract(Name = "SetConnectionRequest")]
internal class SetConnectionRequest
{
    [ProtoMember(1)]
    public string Url { get; set; } = string.Empty;
    [ProtoMember(2)]
    public UrlConnection Connection { get; set; } = new();
}

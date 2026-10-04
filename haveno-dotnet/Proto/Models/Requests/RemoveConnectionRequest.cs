using ProtoBuf;

namespace Haveno.Proto.Models.Requests;

[ProtoContract(Name = "RemoveConnectionRequest")]
internal class RemoveConnectionRequest
{
    [ProtoMember(1)]
    public string Url { get; set; } = string.Empty;
}

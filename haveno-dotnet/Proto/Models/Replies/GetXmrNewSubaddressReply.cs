using ProtoBuf;

namespace Haveno.Proto.Models.Replies;

[ProtoContract(Name = "GetXmrNewSubaddressReply")]
internal class GetXmrNewSubaddressReply
{
    [ProtoMember(1)]
    public string Subaddress { get; set; } = string.Empty;
}

using ProtoBuf;

namespace Haveno.Proto.Models.Replies;

[ProtoContract(Name = "GetXmrPrimaryAddressReply")]
internal class GetXmrPrimaryAddressReply
{
    [ProtoMember(1)]
    public string PrimaryAddress { get; set; } = string.Empty;
}
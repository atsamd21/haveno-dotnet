using ProtoBuf;

namespace Haveno.Proto.Models.Replies;

[ProtoContract(Name = "GetXmrSeedReply")]
internal class GetXmrSeedReply
{
    [ProtoMember(1)]
    public string Seed { get; set; } = string.Empty;
}
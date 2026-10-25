using ProtoBuf;

namespace Haveno.Proto.Models.Replies;

[ProtoContract(Name = "GetAlertReply")]
internal class GetAlertReply
{
    [ProtoMember(1)]
    public Alert Alert { get; set; } = new();
}

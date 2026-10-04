using ProtoBuf;

namespace Haveno.Proto.Models.Replies;

[ProtoContract(Name = "AccountExistsReply")]
internal class AccountExistsReply
{
    [ProtoMember(1)]
    public bool AccountExists { get; set; }
}

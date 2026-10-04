using ProtoBuf;

namespace Haveno.Proto.Models.Replies;

[ProtoContract(Name = "GetChatMessagesReply")]
internal class GetChatMessagesReply
{
    [ProtoMember(1)]
    public List<ChatMessage> Message { get; set; } = [];
}

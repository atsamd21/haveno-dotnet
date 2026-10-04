using ProtoBuf;

namespace Haveno.Proto.Models.Requests;

[ProtoContract(Name = "GetChatMessagesRequest")]
internal class GetChatMessagesRequest
{
    [ProtoMember(1)]
    public string TradeId { get; set; } = string.Empty;
}

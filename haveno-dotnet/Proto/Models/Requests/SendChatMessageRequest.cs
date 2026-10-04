using ProtoBuf;

namespace Haveno.Proto.Models.Requests;

[ProtoContract(Name = "SendChatMessageRequest")]
internal class SendChatMessageRequest
{
    [ProtoMember(1)]
    public string TradeId { get; set; } = string.Empty;
    [ProtoMember(2)]
    public string Message { get; set; } = string.Empty;
}

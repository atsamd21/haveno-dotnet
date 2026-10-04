using ProtoBuf;

namespace Haveno.Proto.Models.Requests;

[ProtoContract(Name = "SendDisputeChatMessageRequest")]
internal class SendDisputeChatMessageRequest
{
    [ProtoMember(1)]
    public string DisputeId { get; set; } = string.Empty;
    [ProtoMember(2)]
    public string Message { get; set; } = string.Empty;
    [ProtoMember(3)]
    public List<Attachment> Attachments { get; set; } = [];
}

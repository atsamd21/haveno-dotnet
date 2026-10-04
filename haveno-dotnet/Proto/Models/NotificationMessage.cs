using Haveno.Proto.Models.Enums;
using ProtoBuf;

namespace Haveno.Proto.Models;

[ProtoContract(Name = "NotificationMessage")]
internal class NotificationMessage
{
    [ProtoMember(1)]
    public string Id { get; set; } = string.Empty;
    [ProtoMember(2)]
    public NotificationType Type { get; set; }
    [ProtoMember(3)]
    public long Timestamp { get; set; }
    [ProtoMember(4)]
    public string Title { get; set; } = string.Empty;
    [ProtoMember(5)]
    public string Message { get; set; } = string.Empty;
    [ProtoMember(6)]
    public TradeInfo? Trade { get; set; }
    [ProtoMember(7)]
    public ChatMessage? ChatMessage { get; set; }
}

using ProtoBuf;

namespace Haveno.Proto.Models.Requests;

[ProtoContract(Name = "SendNotificationRequest")]
internal class SendNotificationRequest
{
    [ProtoMember(1)]
    public NotificationMessage Notification { get; set; } = new();
}

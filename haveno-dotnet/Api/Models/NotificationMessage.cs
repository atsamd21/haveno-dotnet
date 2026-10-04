using Haveno.Api.Models.Enums;

namespace Haveno.Api.Models;

public class NotificationMessage
{
    public string Id { get; set; } = string.Empty;
    public NotificationType Type { get; set; }
    public DateTime Timestamp { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public TradeInfo? Trade { get; set; }
    public ChatMessage? ChatMessage { get; set; }
}

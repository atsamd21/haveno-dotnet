using Haveno.Shared.Enums;

namespace Haveno.Api.Models;

public class ChatMessage
{
    public DateTime Date { get; set; }
    public string TradeId { get; set; } = string.Empty;
    public int TraderId { get; set; }
    public string Message { get; set; } = string.Empty;
    public List<Attachment> Attachments { get; set; } = [];
    public bool HasArrived { get; set; }
    public bool SenderIsTrader { get; set; }
    public bool IsStoredInMailbox { get; set; }
    public bool IsSystemMessage { get; set; }
    public bool IsAcknowledged { get; set; }
    public bool WasDisplayed { get; set; }
    public NodeAddress SenderNodeAddress { get; set; } = new();
    public string Uid { get; set; } = string.Empty;
    public string SendMessageError { get; set; } = string.Empty;
    public string AckError { get; set; } = string.Empty;
    public SupportType Type { get; set; }
}

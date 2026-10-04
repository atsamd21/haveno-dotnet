using Haveno.Shared.Enums;
using ProtoBuf;

namespace Haveno.Proto.Models;

[ProtoContract(Name = "ChatMessage")]
internal class ChatMessage
{
    [ProtoMember(1)]
    public long Date { get; set; }
    [ProtoMember(2)]
    public string TradeId { get; set; } = string.Empty;
    [ProtoMember(3)]
    public int TraderId { get; set; }
    [ProtoMember(4)]
    public bool SenderIsTrader { get; set; }
    [ProtoMember(5)]
    public string Message { get; set; } = string.Empty;
    [ProtoMember(6)]
    public List<Attachment> Attachments { get; set; } = [];
    [ProtoMember(7)]
    public bool Arrived { get; set; }
    [ProtoMember(8)]
    public bool StoredInMailbox { get; set; }
    [ProtoMember(9)]
    public bool IsSystemMessage { get; set; }
    [ProtoMember(10)]
    public NodeAddress SenderNodeAddress { get; set; } = new();
    [ProtoMember(11)]
    public string Uid { get; set; } = string.Empty;
    [ProtoMember(12)]
    public string SendMessageError { get; set; } = string.Empty;
    [ProtoMember(13)]
    public bool Acknowledged { get; set; }
    [ProtoMember(14)]
    public string AckError { get; set; } = string.Empty;
    [ProtoMember(15)]
    public SupportType Type { get; set; }
    [ProtoMember(16)]
    public bool WasDisplayed { get; set; }
}

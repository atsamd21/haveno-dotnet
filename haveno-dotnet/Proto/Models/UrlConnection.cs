using Haveno.Shared.Enums;
using ProtoBuf;

namespace Haveno.Proto.Models;

[ProtoContract(Name = "UrlConnection")]
internal class UrlConnection
{
    [ProtoMember(1)]
    public string Url { get; set; } = string.Empty;
    [ProtoMember(2)]
    public string Username { get; set; } = string.Empty;
    [ProtoMember(3)]
    public string Password { get; set; } = string.Empty;
    [ProtoMember(4)]
    public int Priority { get; set; }
    [ProtoMember(5)]
    public OnlineStatus OnlineStatus { get; set; }
    [ProtoMember(6)]
    public AuthenticationStatus AuthenticationStatus { get; set; }
}

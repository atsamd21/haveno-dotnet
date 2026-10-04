using Haveno.Shared.Enums;

namespace Haveno.Api.Models;

public class UrlConnection
{
    public string Url { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public int Priority { get; set; }
    public OnlineStatus OnlineStatus { get; set; }
    public AuthenticationStatus AuthenticationStatus { get; set; }
}

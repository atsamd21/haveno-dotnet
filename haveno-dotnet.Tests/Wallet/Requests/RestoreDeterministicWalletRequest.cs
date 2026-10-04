using System.Text.Json.Serialization;

namespace Haveno.Tests.Wallet.Requests;

public class RestoreDeterministicWalletRequest
{
    [JsonPropertyName("filename")]
    public string Filename { get; set; } = string.Empty;
    [JsonPropertyName("password")]
    public string Password { get; set; } = string.Empty;
    [JsonPropertyName("seed")]
    public string Seed { get; set; } = string.Empty;
}

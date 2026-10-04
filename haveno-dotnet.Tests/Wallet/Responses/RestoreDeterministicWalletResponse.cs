using System.Text.Json.Serialization;

namespace Haveno.Tests.Wallet.Responses;

public class RestoreDeterministicWalletResponse
{
    [JsonPropertyName("address")]
    public string Address { get; set; } = string.Empty;
    [JsonPropertyName("info")]
    public string Info { get; set; } = string.Empty;
}

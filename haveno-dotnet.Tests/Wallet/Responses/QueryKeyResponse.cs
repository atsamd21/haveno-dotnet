using System.Text.Json.Serialization;

namespace Haveno.Tests.Wallet.Responses;

public class QueryKeyResponse
{
    [JsonPropertyName("key")]
    public string Key { get; set; } = string.Empty;
}

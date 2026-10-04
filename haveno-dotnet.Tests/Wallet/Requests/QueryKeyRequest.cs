using System.Text.Json.Serialization;

namespace Haveno.Tests.Wallet.Requests;

public class QueryKeyRequest
{
    [JsonPropertyName("key_type")]
    public string KeyType { get; set; } = "mnemonic";
}

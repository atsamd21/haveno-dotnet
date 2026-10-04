using System.Text.Json.Serialization;

namespace Haveno.Tests.Wallet.Requests;

public class RefreshRequest
{
    [JsonPropertyName("start_height")]
    public uint StartHeight { get; set; }
}

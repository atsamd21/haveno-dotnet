using System.Text.Json.Serialization;

namespace Haveno.Tests.Wallet;

public class BaseRequest
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = "0";
    [JsonPropertyName("jsonrpc")]
    public string JsonRPC { get; set; } = "2.0";
    [JsonPropertyName("method")]
    public string Method { get; set; }

    public BaseRequest(string method)
    {
        Method = method;
    }
}

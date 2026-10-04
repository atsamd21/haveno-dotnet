using System.Text.Json.Serialization;

namespace Haveno.Tests.Wallet.Responses;

public class RefreshResponse
{
    [JsonPropertyName("blocks_fetched")]
    public uint BlocksFetched { get; set; }
    [JsonPropertyName("received_money")]
    public bool ReceivedMoney { get; set; }
}

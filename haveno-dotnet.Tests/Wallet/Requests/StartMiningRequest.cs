using System.Text.Json.Serialization;

namespace Haveno.Tests.Wallet.Requests;

public class StartMiningRequest
{
    [JsonPropertyName("threads_count")]
    public uint ThreadsCount { get; set; }
    [JsonPropertyName("do_background_mining")]
    public bool DoBackgroundMining { get; set; }
    [JsonPropertyName("ignore_battery")]
    public bool IgnoreBattery { get; set; }
}
using System.Text.Json.Serialization;

namespace Haveno.Tests.Wallet.Requests;

public class GetBalanceRequest
{
    [JsonPropertyName("account_index")]
    public uint AccountIndex { get; set; }
    [JsonPropertyName("address_indices")]
    public uint[] AddressIndices { get; set; } = [];
}
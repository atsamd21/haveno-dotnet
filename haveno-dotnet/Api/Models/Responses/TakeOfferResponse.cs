using Haveno.Shared.Enums;

namespace Haveno.Api.Models.Responses;

public class TakeOfferResponse
{
    public TradeInfo Trade { get; set; } = new();
    public AvailabilityResultWithDescription? AvailabilityResultWithDescription { get; set; }
}

public class AvailabilityResultWithDescription
{
    public AvailabilityResult AvailabilityResult { get; set; }
    public string Description { get; set; } = string.Empty;
}

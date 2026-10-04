using Haveno.Api.Services;
using Microsoft.Extensions.DependencyInjection;
using Xunit.Extensions.Ordering;

namespace Haveno.Tests;

[Order(6)]
[Collection(nameof(SetupCollection))]
[TestCaseOrderer("Haveno.Tests.PriorityOrderer", "haveno-dotnet.Tests")]
public class DisputeAgentTests
{
    private readonly IDisputeAgentService _disputeAgentService;

    public DisputeAgentTests(SetupFixture fixture)
    {
        var serviceProvider = fixture.ServiceProvider;
        _disputeAgentService = serviceProvider.GetRequiredKeyedService<IDisputeAgentService>("arbitrator");
    }

    [Fact, TestPriority(10)]
    public async Task Register_Arbitrator()
    {
        //await _disputeAgentService.RegisterDisputeAgentAsync("arbitrator", "6ac43ea1df2a290c1c8391736aa42e4339c5cb4f110ff0257a13b63211977b7a");
    }
}

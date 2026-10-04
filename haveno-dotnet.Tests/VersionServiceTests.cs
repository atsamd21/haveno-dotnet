using Haveno.Api.Services;
using Microsoft.Extensions.DependencyInjection;
using Xunit.Extensions.Ordering;

namespace Haveno.Tests;

[Order(3)]
[Collection(nameof(SetupCollection))]
[TestCaseOrderer("Haveno.Tests.PriorityOrderer", "haveno-dotnet.Tests")]
public class VersionServiceTests
{
    private readonly IVersionService _versionService;

    public VersionServiceTests(SetupFixture fixture)
    {
        var serviceProvider = fixture.ServiceProvider;
        _versionService = serviceProvider.GetRequiredKeyedService<IVersionService>("user_1");
    }

    [Fact, TestPriority(10)]
    public async Task GetVersion_Should_Return_Version()
    {
        var response = await _versionService.GetVersionAsync();
        Assert.False(string.IsNullOrEmpty(response));
    }
}



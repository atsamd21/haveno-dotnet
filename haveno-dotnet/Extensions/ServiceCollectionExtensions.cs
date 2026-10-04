using Haveno.Api.Services;
using Haveno.Api.Singletons;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Haveno.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddHavenoServices(this IServiceCollection services)
    {
        services.TryAddSingleton<GrpcChannelSingleton>((serviceProvider) =>
        {
            var grpcChannelSingleton = new GrpcChannelSingleton();
            // TODO CONFIG PASSWORD
            grpcChannelSingleton.CreateChannel("http://127.0.0.1:3201", "apitest12345");
            return grpcChannelSingleton;
        });

        services.TryAddSingleton<INotificationsSingleton, NotificationsSingleton>();

        services.TryAddScoped<IAccountService, AccountService>();
        services.TryAddScoped<IVersionService, VersionService>();
        services.TryAddScoped<IWalletService, WalletService>();
        services.TryAddScoped<IOffersService, OffersService>();
        services.TryAddScoped<IDisputeAgentService, DisputeAgentService>();
        services.TryAddScoped<IPaymentAccountService, PaymentAccountService>();
        services.TryAddScoped<ITradeService, TradeService>();
        services.TryAddScoped<IDisputeService, DisputeService>();
        services.TryAddScoped<IPriceService, PriceService>();
        services.TryAddScoped<IXmrNodeService, XmrNodeService>();
        services.TryAddScoped<ITradeStatisticsService, TradeStatisticsService>();
        services.TryAddScoped<IServerService, ServerService>();

        services.AddMemoryCache();

        return services;
    }
}

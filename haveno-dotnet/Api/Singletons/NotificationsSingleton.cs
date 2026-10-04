using Haveno.Api.Models;
using Haveno.Api.Models.Converters;
using Haveno.Proto.Clients;
using ProtoBuf.Grpc.Client;

namespace Haveno.Api.Singletons;

public interface INotificationsSingleton
{
    IAsyncEnumerable<NotificationMessage> RegisterNotificationListenerAsync(CancellationToken cancellationToken = default);
    Task SendNotificationAsync(NotificationMessage notificationMessage, CancellationToken cancellationToken = default);
}

public sealed class NotificationsSingleton : INotificationsSingleton
{
    private readonly GrpcChannelSingleton _grpcChannelSingleton;
    private readonly IHavenoNotificationsClient _notificationsClient;

    public NotificationsSingleton(GrpcChannelSingleton grpcChannelSingleton)
    {
        _grpcChannelSingleton = grpcChannelSingleton;
        _notificationsClient = _grpcChannelSingleton.Channel.CreateGrpcService<IHavenoNotificationsClient>();
    }

    public IAsyncEnumerable<NotificationMessage> RegisterNotificationListenerAsync(CancellationToken cancellationToken = default)
    {
        var response = _notificationsClient.RegisterNotificationListenerAsync(
            new Proto.Models.Requests.RegisterNotificationListenerRequest(), 
            cancellationToken);

        return response.Select(x => x.Convert());
    }

    public async Task SendNotificationAsync(NotificationMessage notificationMessage, CancellationToken cancellationToken = default)
    {
        await _notificationsClient.SendNotificationAsync(
            new Proto.Models.Requests.SendNotificationRequest
            {
                Notification = notificationMessage.Convert()
            },
            cancellationToken);
    }
}

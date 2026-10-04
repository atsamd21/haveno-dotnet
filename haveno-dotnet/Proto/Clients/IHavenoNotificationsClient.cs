using Haveno.Proto.Models;
using Haveno.Proto.Models.Replies;
using Haveno.Proto.Models.Requests;
using System.Runtime.CompilerServices;
using System.ServiceModel;

[assembly: InternalsVisibleTo("ProtoBuf.Grpc.Internal.Proxies")]

namespace Haveno.Proto.Clients;

[ServiceContract(Name = "io.haveno.protobuffer.Notifications")]
internal interface IHavenoNotificationsClient
{
    [OperationContract(Name = "RegisterNotificationListener")]
    IAsyncEnumerable<NotificationMessage> RegisterNotificationListenerAsync(RegisterNotificationListenerRequest registerNotificationListenerRequest, CancellationToken cancellationToken = default);
    [OperationContract(Name = "SendNotification")]
    Task<SendNotificationReply> SendNotificationAsync(SendNotificationRequest sendNotificationRequest, CancellationToken cancellationToken = default);
}

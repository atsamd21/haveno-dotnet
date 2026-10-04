using Haveno.Proto.Models.Replies;
using Haveno.Proto.Models.Requests;
using System.Runtime.CompilerServices;
using System.ServiceModel;

[assembly: InternalsVisibleTo("ProtoBuf.Grpc.Internal.Proxies")]

namespace Haveno.Proto.Clients;

[ServiceContract(Name = "io.haveno.protobuffer.XmrConnections")]
internal interface IHavenoXmrConnectionsClient
{
    [OperationContract(Name = "AddConnection")]
    Task<AddConnectionReply> AddConnectionAsync(AddConnectionRequest addConnectionRequest, CancellationToken cancellationToken = default);
    [OperationContract(Name = "RemoveConnection")]
    Task<RemoveConnectionReply> RemoveConnectionAsync(RemoveConnectionRequest removeConnectionRequest, CancellationToken cancellationToken = default);
    [OperationContract(Name = "GetConnection")]
    Task<GetConnectionReply> GetConnectionAsync(GetConnectionRequest getConnectionRequest, CancellationToken cancellationToken = default);
    [OperationContract(Name = "GetConnections")]
    Task<GetConnectionsReply> GetConnectionsAsync(GetConnectionsRequest getConnectionsRequest, CancellationToken cancellationToken = default);
    [OperationContract(Name = "SetConnection")]
    Task<SetConnectionReply> SetConnectionAsync(SetConnectionRequest setConnectionRequest, CancellationToken cancellationToken = default);
    [OperationContract(Name = "CheckConnection")]
    Task<CheckConnectionReply> CheckConnectionAsync(CheckConnectionRequest checkConnectionRequest, CancellationToken cancellationToken = default);
    [OperationContract(Name = "CheckConnections")]
    Task<CheckConnectionsReply> CheckConnectionsAsync(CheckConnectionsRequest checkConnectionsRequest, CancellationToken cancellationToken = default);
    [OperationContract(Name = "StartCheckingConnection")]
    Task<StartCheckingConnectionReply> StartCheckingConnectionAsync(StartCheckingConnectionRequest startCheckingConnectionRequest, CancellationToken cancellationToken = default);
    [OperationContract(Name = "StopCheckingConnection")]
    Task<StopCheckingConnectionReply> StopCheckingConnectionAsync(StopCheckingConnectionRequest stopCheckingConnectionRequest, CancellationToken cancellationToken = default);
    [OperationContract(Name = "GetBestConnection")]
    Task<GetBestConnectionReply> GetBestConnectionAsync(GetBestConnectionRequest getBestConnectionRequest, CancellationToken cancellationToken = default);
    [OperationContract(Name = "SetAutoSwitch")]
    Task<SetAutoSwitchReply> SetAutoSwitchAsync(SetAutoSwitchRequest setAutoSwitchRequest, CancellationToken cancellationToken = default);
    [OperationContract(Name = "GetAutoSwitch")]
    Task<GetAutoSwitchReply> GetAutoSwitchAsync(GetAutoSwitchRequest getAutoSwitchRequest, CancellationToken cancellationToken = default);
}

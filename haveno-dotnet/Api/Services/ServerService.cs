using Haveno.Api.Singletons;
using Haveno.Proto.Clients;
using ProtoBuf.Grpc.Client;

namespace Haveno.Api.Services;

public interface IServerService
{
    Task StopAsync(CancellationToken cancellationToken = default);
}

public sealed class ServerService : IServerService
{
    private readonly GrpcChannelSingleton _grpcChannelSingleton;
    private readonly IHavenoShutdownServerClient _havenoShutdownServerClient;

    public ServerService(GrpcChannelSingleton grpcChannelSingleton)
    {
        _grpcChannelSingleton = grpcChannelSingleton;
        _havenoShutdownServerClient = _grpcChannelSingleton.Channel.CreateGrpcService<IHavenoShutdownServerClient>();
    }

    public async Task StopAsync(CancellationToken cancellationToken = default)
    {
        await _havenoShutdownServerClient.StopAsync(
            new Proto.Models.Requests.StopRequest(), 
            cancellationToken);
    }
}

using Haveno.Api.Singletons;
using Haveno.Proto.Clients;
using ProtoBuf.Grpc.Client;

namespace Haveno.Api.Services;

public interface IVersionService
{
    Task<string> GetVersionAsync(CancellationToken cancellationToken = default);
}

public sealed class VersionService : IVersionService
{
    private readonly GrpcChannelSingleton _grpcChannelSingleton;
    private readonly IHavenoVersionClient _havenoVersionClient;

    public VersionService(GrpcChannelSingleton grpcChannelSingleton)
    {
        _grpcChannelSingleton = grpcChannelSingleton;
        _havenoVersionClient = _grpcChannelSingleton.Channel.CreateGrpcService<IHavenoVersionClient>();
    }

    // Cache?
    public async Task<string> GetVersionAsync(CancellationToken cancellationToken = default)
    {
        var response = await _havenoVersionClient.GetVersionAsync(
            new Proto.Models.Requests.GetVersionRequest(), 
            cancellationToken);
        
        return response.Version; 
    }
}

using Grpc.Core;

namespace Haveno.Extensions;

public static class RpcExceptionExtensions
{
    public static string GetErrorMessage(this RpcException rpcException)
    {
        return rpcException.Message.Split("Detail=\"")[1].TrimEnd("\")").ToString();
    }
}

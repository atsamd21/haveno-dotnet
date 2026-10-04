namespace Haveno.Tests;

public static class TestHelper
{
    /// <summary>
    /// Keeps polling method until timeout or predicate is true
    /// </summary>
    /// <typeparam name="TResponse"></typeparam>
    /// <param name="method"></param>
    /// <param name="predicate"></param>
    /// <param name="timeout"></param>
    /// <param name="arguments"></param>
    /// <returns></returns>
    public static async Task<bool> PollWithTimeoutAsync<TResponse>(Delegate method, Func<TResponse, bool> predicate, int timeout = 30_000, params object?[] arguments)
    {
        try
        {
            using CancellationTokenSource cancellationTokenSource = new(timeout);
            while (!cancellationTokenSource.Token.IsCancellationRequested)
            {
                TResponse response;

                var parameters = method.Method.GetParameters();
                if (parameters.LastOrDefault(x => x.Name == "cancellationToken") is not null)
                {
                    response = await (Task<TResponse>)method.DynamicInvoke(arguments.Concat([cancellationTokenSource.Token]).ToArray())!;
                }
                else
                {
                    response = await (Task<TResponse>)method.DynamicInvoke(arguments)!;
                }

                if (predicate(response))
                    return true;

                await Task.Delay(1_000, cancellationTokenSource.Token);
            }
        }
        catch
        {

        }

        return false;
    }
}

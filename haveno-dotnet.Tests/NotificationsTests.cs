using Grpc.Core;
using Haveno.Api.Models;
using Haveno.Api.Models.Enums;
using Haveno.Api.Services;
using Haveno.Api.Singletons;
using Microsoft.Extensions.DependencyInjection;
using Xunit.Extensions.Ordering;

namespace Haveno.Tests;

[Order(2)]
[Collection(nameof(SetupCollection))]
[TestCaseOrderer("Haveno.Tests.PriorityOrderer", "haveno-dotnet.Tests")]
public class NotificationsTests
{
    private readonly INotificationsSingleton _notificationsSingleton;
    private readonly IAccountService _accountService;

    public NotificationsTests(SetupFixture fixture)
    {
        var serviceProvider = fixture.ServiceProvider;
        _notificationsSingleton = serviceProvider.GetRequiredKeyedService<INotificationsSingleton>("user_1");
        _accountService = serviceProvider.GetRequiredKeyedService<IAccountService>("user_1");
    }

    private async Task<bool> SendTestMessage(NotificationMessage notificationMessage)
    {
        using CancellationTokenSource cancellationTokenSource = new(5_000);
        var stream = _notificationsSingleton.RegisterNotificationListenerAsync(cancellationTokenSource.Token);

        var messageReceivedTCS = new TaskCompletionSource<bool>();

        _ = Task.Run(async () =>
        {
            try
            {
                await foreach (var notification in stream)
                {
                    if (notification.Type == NotificationType.ChatMessage &&
                        notification.ChatMessage is not null &&
                        notification.ChatMessage.Message == notificationMessage.ChatMessage?.Message)
                    {
                        break;
                    }
                    else if (notification.Type == NotificationType.TradeUpdate &&
                            notification.Trade is not null &&
                            notification.Trade.Amount == notificationMessage.Trade?.Amount)
                    {
                        break;
                    }
                }

                messageReceivedTCS.TrySetResult(true);
            }
            catch (RpcException)
            {
                messageReceivedTCS.TrySetResult(false);
            }
        });

        await Task.Delay(1_000);

        await _notificationsSingleton.SendNotificationAsync(notificationMessage);

        return await messageReceivedTCS.Task;
    }

    [Fact, TestPriority(10)]
    public async Task NotificationSingleton_Receives_Test_Message()
    {
        var chatMessageReceived = await SendTestMessage(new NotificationMessage
        {
            Type = NotificationType.ChatMessage,
            ChatMessage = new ChatMessage
            {
                Message = "TEST MESSAGE",
            }
        });    

        Assert.True(chatMessageReceived);

        //var tradeUpdateReceived = await SendTestMessage(new NotificationMessage
        //{
        //    Type = NotificationType.TradeUpdate,
        //    Trade = new TradeInfo
        //    {
        //        Amount = 9_999
        //    }
        //});

        //Assert.True(tradeUpdateReceived);
    }

    [Fact, TestPriority(20)]
    public async Task NotificationSingleton_Receives_AppInitialized_Message()
    {
        var messageReceivedTCS = new TaskCompletionSource<bool>();

        _ = Task.Run(async () =>
        {
            try
            {
                using CancellationTokenSource cancellationTokenSource = new(120_000);
                var stream = _notificationsSingleton.RegisterNotificationListenerAsync(cancellationTokenSource.Token);

                await foreach (var notification in stream)
                {
                    if (notification.Type == NotificationType.AppInitialized)
                    {
                        messageReceivedTCS.SetResult(true);
                    }
                }
            }
            catch (RpcException)
            {
                messageReceivedTCS.TrySetResult(false);
            }
        });

        await _accountService.CloseAccountAsync();
        await _accountService.OpenAccountAsync(SetupFixture.AccountPassword);

        Assert.True(await messageReceivedTCS.Task);
    }
}

using Microsoft.AspNetCore.SignalR;

namespace SignalRGroupChatApp
{
    public class ChatHubFilter : IHubFilter
    {
        public async ValueTask<object?> InvokeMethodAsync(
            HubInvocationContext context,
            Func<HubInvocationContext, ValueTask<object?>> next)
        {
            Console.WriteLine($"Invoke method {context.HubMethodName}");
            try
            {
                return await next(context);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Not invoke method {context.HubMethodName}: {ex.Message}");
                throw;
            }
        }
    }
}

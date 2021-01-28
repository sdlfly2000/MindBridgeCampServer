using Common.Core.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Net.WebSockets;
using System.Threading;
using System;

namespace MindBridgeCampServer.Middlewares
{
    [ServiceLocate(typeof(IWebSocketNotifyMiddleware))]
    public class WebSocketNotifyMiddleware : IWebSocketNotifyMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (context.WebSockets.IsWebSocketRequest)
            {
                using (var webSocket = await context.WebSockets.AcceptWebSocketAsync())
                {
                    var socketFinishedTcs = new TaskCompletionSource<object>();

                    var buffer = WebSocket.CreateServerBuffer(255);

                    var response = await webSocket.ReceiveAsync(buffer, CancellationToken.None);

                    Console.WriteLine(buffer.ToString());

                    await socketFinishedTcs.Task;
                }
            }
            await next(context);
        }
    }

    public static class WebSocketNotifyMiddlewareExtentions
    {
        public static IApplicationBuilder UseWebSocketNotify(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<IWebSocketNotifyMiddleware>();
        }
    }
}

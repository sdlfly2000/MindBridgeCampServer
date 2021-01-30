using Microsoft.AspNetCore.Builder;
using System.Threading.Tasks;
using System.Net.WebSockets;
using System.Threading;
using System;
using System.Collections.Generic;

public static class WebSocketRouterMiddlewareExtentions
{
    public static IApplicationBuilder UseWebSocketRouter(this IApplicationBuilder builder, Dictionary<string, Type> patternTypePairs)
    {
        return builder.Use(
            async (context, next) =>
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

                await next.Invoke();
            }
        );
    }
}

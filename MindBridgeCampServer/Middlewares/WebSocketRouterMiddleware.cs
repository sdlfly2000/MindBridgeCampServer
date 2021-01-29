using Common.Core.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Net.WebSockets;
using System.Threading;
using System;

namespace MindBridgeCampServer.Middlewares
{
    using System.Collections.Generic;

    [ServiceLocate(typeof(IWebSocketRouterMiddleware))]
    public class WebSocketRouterMiddleware : IWebSocketRouterMiddleware
    {
        private readonly Dictionary<string, Type> _patternTypePairs;
        private readonly IServiceProvider _provider;

        public WebSocketRouterMiddleware(Dictionary<string, Type> patternTypePairs, IServiceProvider provider)
        {
            _patternTypePairs = patternTypePairs;
            _provider = provider;
        }

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
        public static IApplicationBuilder UseWebSocketRouter(this IApplicationBuilder builder, Dictionary<string, Type> patternTypePairs)
        {
            return builder.UseMiddleware<IWebSocketRouterMiddleware>(patternTypePairs, builder.ApplicationServices);
        }
    }
}

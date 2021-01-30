using Microsoft.AspNetCore.Builder;
using System.Threading.Tasks;
using System.Net.WebSockets;
using System.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using MindBridgeCampServer.Hubs;

public static class WebSocketRouterMiddlewareExtentions
{
    public static IApplicationBuilder UseWebSocketRouter(this IApplicationBuilder builder, Dictionary<string, Type> patternTypePairs)
    {
        return builder.Use(
            async (context, next) =>
            {
                if (context.WebSockets.IsWebSocketRequest)
                {
                    var hub = GetService(builder, patternTypePairs, context.Request.Path) as IWebSocketHub;

                    if (hub != null)
                    {
                        using (var webSocket = await context.WebSockets.AcceptWebSocketAsync())
                        {
                            var socketFinishedTcs = new TaskCompletionSource<object>();

                            hub.SetWebSocket(webSocket, socketFinishedTcs);

                            await socketFinishedTcs.Task;
                        }
                    }
                }

                await next.Invoke();
            }
        );
    }

    #region Private Methods

    private static object GetService(IApplicationBuilder builder, Dictionary<string, Type> patternTypePairs, PathString requestPattern)
    {
        var registeredPatterns = patternTypePairs.Keys.Select(p => PathString.FromUriComponent(p)).ToList();
        var matchedPattern = new PathString();
        var remainingPattern = new PathString();

        if (registeredPatterns.Any(r => requestPattern.StartsWithSegments(r, out matchedPattern, out remainingPattern)))
        {
            var service = patternTypePairs.GetValueOrDefault(matchedPattern);

            return service != null
                ? builder.ApplicationServices.GetService(service)
                : null;
        }

        return null;
    }

    #endregion
}

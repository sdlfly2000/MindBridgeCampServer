using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using MindBridgeCampServer.Hubs;
using Microsoft.Extensions.DependencyInjection;

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
                            await hub.Execute(webSocket, context.Request.Path);
                            return;
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

            var serviceScopeFactory = builder.ApplicationServices.GetService<IServiceScopeFactory>();

            using (var scope = serviceScopeFactory.CreateScope())
            {
                return service != null
                    ? scope.ServiceProvider.GetService(service)
                    : null;
            }
        }

        return null;
    }

    #endregion
}

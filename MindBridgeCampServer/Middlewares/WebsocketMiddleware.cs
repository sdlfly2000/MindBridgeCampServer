using Common.Core.DependencyInjection;
using Microsoft.AspNetCore.Http;
using MindBridgeCampServer.Hubs;
using System.Threading.Tasks;

namespace MindBridgeCampServer.Middlewares
{
    [ServiceLocate(typeof(IWebsocketMiddleware))]
    public class WebsocketMiddleware : IWebsocketMiddleware
    {
        private readonly IChatMessageHub _chatHub;

        public WebsocketMiddleware(IChatMessageHub chatHub)
        {
            _chatHub = chatHub;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (context.WebSockets.IsWebSocketRequest)
            {
                var hub = _chatHub as IWebSocketHub;

                if (hub != null)
                {
                    using (var webSocket = await context.WebSockets.AcceptWebSocketAsync())
                    {
                        await hub.Execute(webSocket, context.Request.Path);
                        return;
                    }
                }
            }

            await next.Invoke(context);
        }
    }
}

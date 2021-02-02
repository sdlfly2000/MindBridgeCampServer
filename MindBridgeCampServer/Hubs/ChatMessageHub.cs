using Common.Core.Cache.Client.Utils;
using Common.Core.DependencyInjection;
using Common.Core.LogService;
using Microsoft.AspNetCore.Http;
using System;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;

namespace MindBridgeCampServer.Hubs
{
    [ServiceLocate(typeof(IChatMessageHub))]
    public class ChatMessageHub : IChatMessageHub
    {
        private WebSocket _webSocket;

        private delegate Task OnCreateWebSocketReceive();
        private event OnCreateWebSocketReceive WebSocketReceiveEvent;

        private delegate Task OnReceiveMessage(string connectionId, string message);
        private event OnReceiveMessage OnReceiveMessageEvent;

        private delegate Task OnDisconnect(string connectionId);
        private event OnDisconnect OnDisconnectEvent;

        public ChatMessageHub()
        {
            WebSocketReceiveEvent += OnCreateWebSocketReceiveHandler;
            OnReceiveMessageEvent += OnReceiveMessageHandler;
            OnDisconnectEvent += OnDisconnectHandler;
        }

        public async Task Execute(WebSocket webSocket, PathString patchString)
        {
            _webSocket = webSocket;

            await OnCreateWebSocketReceiveHandler();
        }

        private async Task OnDisconnectHandler(string connectionId)
        {
            LogService.Info<ChatMessageHub>(connectionId + ": " + "WebSocket Close" + Environment.NewLine);
        }

        private async Task OnReceiveMessageHandler(string connectionId, string message)
        {
            LogService.Info<ChatMessageHub>(connectionId + ": " + message + Environment.NewLine);
        }

        private async Task OnCreateWebSocketReceiveHandler()
        {
            var buffer = WebSocket.CreateServerBuffer(255);

            var result = await _webSocket.ReceiveAsync(buffer, CancellationToken.None);

            if(result.MessageType != WebSocketMessageType.Close)
            {
                var message = ConvertTools.BytesToString(buffer.ToArray()).Trim();
                await OnReceiveMessageHandler(_webSocket.GetHashCode().ToString(), message);
            }

            if (_webSocket.State == WebSocketState.Open)
            {
                await WebSocketReceiveEvent();
            }
            else
            {
                await OnDisconnectEvent(_webSocket.GetHashCode().ToString());
            }
        }
    }
}

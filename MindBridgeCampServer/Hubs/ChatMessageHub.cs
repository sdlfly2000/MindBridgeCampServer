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
        private ArraySegment<byte> _buffer;
        private WebSocket _webSocket;

        private delegate Task OnCreateWebSocketReceive(WebSocket websocket);
        private event OnCreateWebSocketReceive OnConnectEvent;

        private delegate Task OnReceiveMessage(string connectionId, string message);
        private event OnReceiveMessage OnReceiveMessageEvent;

        private delegate Task OnDisconnect(string connectionId);
        private event OnDisconnect OnDisconnectEvent;

        public ChatMessageHub()
        {
            OnConnectEvent += OnConnectHandler;
            OnReceiveMessageEvent += OnReceiveMessageHandler;
            OnDisconnectEvent += OnDisconnectHandler;
        }

        public async Task Execute(WebSocket webSocket, PathString patchString)
        {
            _webSocket = webSocket;
            _buffer = WebSocket.CreateServerBuffer(255);

            await WebsocketLifeCycle(webSocket);
        }

        private async Task OnDisconnectHandler(string connectionId)
        {
            LogService.Info<ChatMessageHub>(connectionId + ": " + "WebSocket Close" + Environment.NewLine);
        }

        private async Task OnReceiveMessageHandler(string connectionId, string message)
        {
            LogService.Info<ChatMessageHub>(connectionId + ": " + message + Environment.NewLine);
        }

        private async Task OnConnectHandler(WebSocket webSocket)
        {
            LogService.Info<ChatMessageHub>(webSocket.GetHashCode().ToString() + " Connected" + Environment.NewLine);
        }

        private async Task WebsocketLifeCycle(WebSocket webSocket)
        {
            await OnConnectHandler(webSocket);

            while (webSocket.State == WebSocketState.Open) 
            {
                var result = await webSocket.ReceiveAsync(_buffer, CancellationToken.None);

                if (result.MessageType != WebSocketMessageType.Close)
                {
                    var message = ConvertTools.BytesToString(_buffer.ToArray()).Trim();
                    await OnReceiveMessageHandler(webSocket.GetHashCode().ToString(), message);
                }
            }

            await OnDisconnectEvent(webSocket.GetHashCode().ToString());
        }
    }
}

using Common.Core.Cache.Client.Utils;
using Common.Core.DependencyInjection;
using Common.Core.LogService;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;

namespace MindBridgeCampServer.Hubs
{
    [ServiceLocate(typeof(IChatMessageHub))]
    public class ChatMessageHub : IChatMessageHub
    {
        private ArraySegment<byte> _buffer;

        private static Dictionary<string, List<WebSocket>> _websockets = new Dictionary<string, List<WebSocket>>(); 

        private delegate Task OnCreateWebSocketReceive(WebSocket websocket, string roomId);
        private event OnCreateWebSocketReceive OnConnectEvent;

        private delegate Task OnReceiveMessage(WebSocket websocket, string message);
        private event OnReceiveMessage OnReceiveMessageEvent;

        private delegate Task OnDisconnect(WebSocket websocket);
        private event OnDisconnect OnDisconnectEvent;

        public ChatMessageHub()
        {
            OnConnectEvent += OnConnectHandler;
            OnReceiveMessageEvent += OnReceiveMessageHandler;
            OnDisconnectEvent += OnDisconnectHandler;
        }

        public async Task Execute(WebSocket webSocket, PathString pathString)
        {
            var roomId = pathString.ToUriComponent().Split("/")[2];

            _buffer = WebSocket.CreateServerBuffer(255);

            await WebsocketLifeCycle(webSocket, roomId);
        }

        #region Events

        private async Task OnDisconnectHandler(WebSocket websocket)
        {
            _websockets.Values.FirstOrDefault(ws => ws.Contains(websocket)).Remove(websocket);
            LogService.Info<ChatMessageHub>(websocket.GetHashCode().ToString() + ": " + "WebSocket Close" + Environment.NewLine);
        }

        private async Task OnReceiveMessageHandler(WebSocket websocket, string message)
        {
            LogService.Info<ChatMessageHub>(websocket.GetHashCode().ToString() + ": " + message + Environment.NewLine);
        }

        private async Task OnConnectHandler(WebSocket webSocket, string roomId)
        {
            var websockets = new List<WebSocket>();

            if (_websockets.TryGetValue(roomId, out websockets))
            {
                websockets.Add(webSocket);
            }
            else
            {
                _websockets.Add(roomId, new List<WebSocket> { webSocket });
            }

            LogService.Info<ChatMessageHub>(webSocket.GetHashCode().ToString() + " Connected" + Environment.NewLine);
            LogService.Info<ChatMessageHub>(string.Format("Number of WebSockets Room {0}: {1}", roomId, _websockets[roomId].Count) + Environment.NewLine);
        }

        #endregion

        #region LifeCycle

        private async Task WebsocketLifeCycle(WebSocket webSocket, string roomId)
        {
            await OnConnectEvent(webSocket, roomId);

            while (webSocket.State == WebSocketState.Open) 
            {
                var result = await webSocket.ReceiveAsync(_buffer, CancellationToken.None);

                if (result.MessageType != WebSocketMessageType.Close)
                {
                    var message = ConvertTools.BytesToString(_buffer.ToArray()).Trim();
                    await OnReceiveMessageEvent(webSocket, message);
                }
            }

            await OnDisconnectEvent(webSocket);
        }

        #endregion
    }
}

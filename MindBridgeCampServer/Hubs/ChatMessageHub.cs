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

        private delegate Task OnReceiveMessage(string roomId, string message, string loginToken);
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
            var loginToken = pathString.ToUriComponent().Split("/")[3];

            _buffer = WebSocket.CreateServerBuffer(255);

            await WebsocketLifeCycle(webSocket, roomId, loginToken);
        }

        #region Events

        private async Task OnDisconnectHandler(WebSocket websocket)
        {
            _websockets.Values.FirstOrDefault(ws => ws.Contains(websocket)).Remove(websocket);
            LogService.Info<ChatMessageHub>(websocket.GetHashCode().ToString() + ": " + "WebSocket Close" + Environment.NewLine);
        }

        private async Task OnReceiveMessageHandler(string roomId, string message, string loginToken)
        {
            var websockets = new List<WebSocket>();
            var sendMessage = loginToken + ":" + message;
            var buffer = new ArraySegment<byte>(ConvertTools.StringToBytes(sendMessage));

            if(_websockets.TryGetValue(roomId, out websockets))
            {
                websockets.ForEach(w => w.SendAsync(buffer, WebSocketMessageType.Text, true, CancellationToken.None));
            }
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

        private async Task WebsocketLifeCycle(WebSocket webSocket, string roomId, string loginToken)
        {
            await OnConnectEvent(webSocket, roomId);

            while (webSocket.State == WebSocketState.Open) 
            {
                var result = await webSocket.ReceiveAsync(_buffer, CancellationToken.None);

                if (result.MessageType != WebSocketMessageType.Close)
                {
                    var message = ConvertTools.BytesToString(_buffer.ToArray()).Trim();
                    await OnReceiveMessageEvent(roomId, message, loginToken);
                }
            }

            await OnDisconnectEvent(webSocket);
        }

        #endregion
    }
}

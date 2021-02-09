using Application.Services.LearningRoom;
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
    [ServiceLocate(typeof(IChatMessageHub), ServiceType.Scoped)]
    public class ChatMessageHub : IChatMessageHub
    {
        private readonly ILearningRoomService _learningRoomService;

        private ArraySegment<byte> _buffer;

        private static Dictionary<string, Dictionary<string, WebSocket>> _websockets = new Dictionary<string, Dictionary<string, WebSocket>>(); 

        private delegate Task OnCreateWebSocketReceive(WebSocket websocket, string roomId, string loginToken);
        private event OnCreateWebSocketReceive OnConnectEvent;

        private delegate Task OnReceiveMessage(string roomId, string message, string loginToken);
        private event OnReceiveMessage OnReceiveMessageEvent;

        private delegate Task OnDisconnect(WebSocket websocket, string roomId, string loginToken);
        private event OnDisconnect OnDisconnectEvent;

        public ChatMessageHub(ILearningRoomService learningRoomService)
        {
            OnConnectEvent += OnConnectHandler;
            OnReceiveMessageEvent += OnReceiveMessageHandler;
            OnDisconnectEvent += OnDisconnectHandler;

            _learningRoomService = learningRoomService;
        }

        public async Task Execute(WebSocket webSocket, PathString pathString)
        {
            var roomId = pathString.ToUriComponent().Split("/")[2];
            var loginToken = pathString.ToUriComponent().Split("/")[3];

            _buffer = WebSocket.CreateServerBuffer(255);

            await WebsocketLifeCycle(webSocket, roomId, loginToken);
        }

        #region Events

        private async Task OnDisconnectHandler(WebSocket websocket, string roomId, string loginToken)
        {
            var websockets = new Dictionary<string, WebSocket>();
            _websockets.TryGetValue(roomId, out websockets);
            websockets.Remove(loginToken);
            LogService.Info<ChatMessageHub>(websocket.GetHashCode().ToString() + ": " + "WebSocket Close");
        }

        private async Task OnReceiveMessageHandler(string roomId, string message, string loginToken)
        {
            var websockets = new Dictionary<string, WebSocket>();
            var sendMessage = loginToken + ":" + message;
            var buffer = new ArraySegment<byte>(ConvertTools.StringToBytes(sendMessage));

            if(_websockets.TryGetValue(roomId, out websockets))
            {
                websockets
                    .Select(w => w.Value)
                    .ToList()
                    .ForEach(async w => await w.SendAsync(buffer, WebSocketMessageType.Text, true, CancellationToken.None));
            }

            try
            {
                await _learningRoomService.CreateChatMessage(loginToken, roomId, message);
            }
            catch(Exception e)
            {
                LogService.Info<ChatMessageHub>(
                    e.Message + Environment.NewLine +
                    e.StackTrace);
            }
        }

        private async Task OnConnectHandler(WebSocket webSocket, string roomId, string loginToken)
        {
            var websockets = new Dictionary<string, WebSocket>();

            if (_websockets.Count > 0 &&
                _websockets.TryGetValue(roomId, out websockets))
            {
                websockets.Add(loginToken, webSocket);
            }
            else
            {
                websockets.Add(loginToken, webSocket);
                _websockets.Add(roomId, websockets);
            }

            LogService.Info<ChatMessageHub>(webSocket.GetHashCode().ToString() + " Connected" + Environment.NewLine);
            LogService.Info<ChatMessageHub>(string.Format("Number of WebSockets Room {0}: {1}", roomId, _websockets[roomId].Count) + Environment.NewLine);
        }

        #endregion

        #region LifeCycle

        private async Task WebsocketLifeCycle(WebSocket webSocket, string roomId, string loginToken)
        {
            await OnConnectEvent(webSocket, roomId, loginToken);

            while (webSocket.State == WebSocketState.Open) 
            {
                var result = await webSocket.ReceiveAsync(_buffer, CancellationToken.None);

                if (result.MessageType != WebSocketMessageType.Close)
                {
                    var message = ConvertTools.BytesToString(_buffer.ToArray()).Trim();
                    await OnReceiveMessageEvent(roomId, message, loginToken);
                }
            }

            await OnDisconnectEvent(webSocket, roomId, loginToken);
        }

        #endregion
    }
}

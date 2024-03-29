﻿using Application.LearningRoom;
using Application.Services.LearningRoom;
using Application.Services.User;
using Application.Services.User.Contracts;
using Common.Core.Cache.Client.Utils;
using Common.Core.DependencyInjection;
using Common.Core.LogService;
using Core;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
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
        private readonly IUserService _userService;

        private ArraySegment<byte> _buffer;

        private static Dictionary<string, Dictionary<string, WebSocket>> _websockets = new Dictionary<string, Dictionary<string, WebSocket>>(); 

        private delegate Task OnCreateWebSocketReceive(WebSocket websocket, string roomId, string loginToken);
        private event OnCreateWebSocketReceive OnConnectEvent;

        private delegate Task OnReceiveMessage(string roomId, string message, string loginToken);
        private event OnReceiveMessage OnReceiveMessageEvent;

        private delegate Task OnDisconnect(WebSocket websocket, string roomId, string loginToken);
        private event OnDisconnect OnDisconnectEvent;

        public ChatMessageHub(
            ILearningRoomService learningRoomService,
            IUserService userService)
        {
            OnConnectEvent += OnConnectHandler;
            OnReceiveMessageEvent += OnReceiveMessageHandler;
            OnDisconnectEvent += OnDisconnectHandler;

            _learningRoomService = learningRoomService;
            _userService = userService;
        }

        public int GetParticpantsOnlineCount(string roomId)
        {
            var clients = new Dictionary<string, WebSocket>();

            if(_websockets.TryGetValue(roomId, out clients))
            {
                return clients.Count;
            }

            return 0;
        }

        public async Task Execute(WebSocket webSocket, PathString pathString)
        {
            var roomId = pathString.ToUriComponent().Split("/")[1];
            var loginToken = pathString.ToUriComponent().Split("/")[2];

            _buffer = WebSocket.CreateServerBuffer(255);

            await WebsocketLifeCycle(webSocket, roomId, loginToken);
        }

        #region Events

        private async Task OnDisconnectHandler(WebSocket websocket, string roomId, string loginToken)
        {
            var websockets = new Dictionary<string, WebSocket>();
            _websockets.TryGetValue(roomId, out websockets);
            websockets.Remove(loginToken);
            websocket.Dispose();
            LogService.Info<ChatMessageHub>(websocket.GetHashCode().ToString() + ": " + "WebSocket Close");
        }

        private async Task OnReceiveMessageHandler(string roomId, string message, string loginToken)
        {
            var messageContent = message.Replace("\u0000", string.Empty).Trim();
            var websockets = new Dictionary<string, WebSocket>();

            var userModel = _userService.Get(new GetByLoginTokenRequest 
            { 
                LoginToken = loginToken
            }).User;

            var messageModel = new LearningRoomMessageModel
            {
                CreatedByNickName = userModel.NickName,
                Content = messageContent,
                CreatedOn = DateTimeUtil.GetNow(),
                IsCreatedByRequester = false
            };

            if (_websockets.TryGetValue(roomId, out websockets))
            {
                var bufferToMember = new ArraySegment<byte>(ConvertTools.StringToBytes(JsonConvert.SerializeObject(messageModel)));
                websockets
                    .Where(w => !w.Key.Equals(loginToken))
                    .Select(w => w.Value)
                    .ToList()
                    .ForEach(async w => await w.SendAsync(bufferToMember, 
                        WebSocketMessageType.Text, true, CancellationToken.None));

                messageModel.IsCreatedByRequester = true;
                var bufferToRequester = new ArraySegment<byte>(ConvertTools.StringToBytes(JsonConvert.SerializeObject(messageModel)));
                await websockets
                    .FirstOrDefault(w => w.Key.Equals(loginToken)).Value
                    .SendAsync(bufferToRequester,
                        WebSocketMessageType.Text, true, CancellationToken.None);
            }

            try
            {
                await _learningRoomService.CreateChatMessage(loginToken, roomId, messageContent);
                LogService.Info<ChatMessageHub>(
                    "Message Saved" + Environment.NewLine +
                    "Message: " + messageContent + Environment.NewLine +
                    "Room Id: " + roomId + Environment.NewLine + 
                    "login Token: " + loginToken);
            }
            catch (Exception e)
            {
                LogService.Info<ChatMessageHub>(
                    e.Message + Environment.NewLine +
                    e.StackTrace);
            }
        }

        private async Task OnConnectHandler(WebSocket webSocket, string roomId, string loginToken)
        {
            var websockets = GetWebSocketByRoomId(roomId);
            if (!websockets.TryAdd(loginToken, webSocket))
            {
                websockets[loginToken] = webSocket;
            }

            if (!_websockets.TryAdd(roomId, websockets))
            {
                _websockets[roomId] = websockets;
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
                    var byteReceive = _buffer.AsSpan<byte>().Slice(0, result.Count).ToArray();
                    var message = ConvertTools.BytesToString(byteReceive).Trim();
                    await OnReceiveMessageEvent(roomId, message, loginToken);
                }
            }

            await OnDisconnectEvent(webSocket, roomId, loginToken);
        }

        #endregion

        #region Private Methods

        private Dictionary<string, WebSocket> GetWebSocketByRoomId(string roomId)
        {
            var websockets = new Dictionary<string, WebSocket>();

            if (_websockets.TryGetValue(roomId, out websockets))
            {
                return websockets;
            }

            return new Dictionary<string, WebSocket>();
        }

        #endregion
    }
}

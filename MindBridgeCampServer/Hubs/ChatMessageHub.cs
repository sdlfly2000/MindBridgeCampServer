using Common.Core.Cache.Client.Utils;
using Common.Core.DependencyInjection;
using Common.Core.LogService;
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
        private TaskCompletionSource<object> _tc;

        private delegate void OnCreateWebSocketReceive();
        private event OnCreateWebSocketReceive WebSocketReceiveEvent;

        public ChatMessageHub()
        {
            WebSocketReceiveEvent += OnCreateWebSocketReceiveHandler;
        }

        public void SetWebSocket(WebSocket webSocket, TaskCompletionSource<object> tc)
        {
            _webSocket = webSocket;
            _tc = tc;

            WebSocketReceiveEvent();
        }

        private async void OnCreateWebSocketReceiveHandler()
        {
            var buffer = WebSocket.CreateServerBuffer(255);

            await _webSocket.ReceiveAsync(buffer, CancellationToken.None);

            LogService.Info<ChatMessageHub>(ConvertTools.BytesToString(buffer.ToArray()) + Environment.NewLine);

            if (_webSocket.State == WebSocketState.Open)
            {
                WebSocketReceiveEvent();
            }
            else
            {
                LogService.Info<ChatMessageHub>("WebSocket Close" + Environment.NewLine);
            }
        }
    }
}

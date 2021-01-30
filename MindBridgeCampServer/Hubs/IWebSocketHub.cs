using System.Net.WebSockets;
using System.Threading.Tasks;

namespace MindBridgeCampServer.Hubs
{
    public interface IWebSocketHub
    {
        void SetWebSocket(WebSocket webSocket, TaskCompletionSource<object> tc);
    }
}

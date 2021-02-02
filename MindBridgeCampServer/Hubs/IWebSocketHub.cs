using Microsoft.AspNetCore.Http;
using System;
using System.Net.WebSockets;
using System.Threading.Tasks;

namespace MindBridgeCampServer.Hubs
{
    public interface IWebSocketHub
    {
        Task Execute(WebSocket webSocket, PathString patchString);
    }
}

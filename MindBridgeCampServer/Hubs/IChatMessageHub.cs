namespace MindBridgeCampServer.Hubs
{
    public interface IChatMessageHub : IWebSocketHub
    {
        int GetParticpantsOnlineCount(string roomId);
    }
}

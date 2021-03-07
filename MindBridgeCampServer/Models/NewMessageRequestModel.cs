namespace MindBridgeCampServer.Models
{
    public class NewMessageRequestModel
    {
        public string loginToken { get; set; }
        public string roomId { get; set; }
        public string content { get; set; }
    }
}

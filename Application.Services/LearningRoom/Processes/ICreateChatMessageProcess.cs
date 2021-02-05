using System.Threading.Tasks;

namespace Application.Services.LearningRoom.Processes
{
    public interface ICreateChatMessageProcess
    {
        Task CreateChatMessage(string loginToken, string roomId, string message);
    }
}

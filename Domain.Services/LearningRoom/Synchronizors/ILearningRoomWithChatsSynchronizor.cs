using Domain.LearningRoom;
using System.Threading.Tasks;

namespace Domain.Services.LearningRoom.Synchronizors
{
    public interface ILearningRoomWithChatsSynchronizor
    {
        Task Update(ILearningRoomWithChats learningRoom);
    }
}

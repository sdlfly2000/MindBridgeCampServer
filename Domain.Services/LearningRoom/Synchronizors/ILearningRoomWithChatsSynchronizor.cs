using Domain.LearningRoom;

namespace Domain.Services.LearningRoom.Synchronizors
{
    public interface ILearningRoomWithChatsSynchronizor
    {
        void Update(ILearningRoomWithChats learningRoom);
    }
}

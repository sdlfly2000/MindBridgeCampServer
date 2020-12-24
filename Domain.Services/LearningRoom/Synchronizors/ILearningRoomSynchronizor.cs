using Domain.LearningRoom;

namespace Domain.Services.LearningRoom.Synchronizors
{
    public interface ILearningRoomSynchronizor
    {
        void Add(ILearningRoom learningRoom);

        void Update(ILearningRoom learningRoom);
    }
}

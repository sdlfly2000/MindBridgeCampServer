using Domain.LearningRoom;

namespace Domain.Services.LearningRoom.Synchronizors
{
    public interface ILearningRoomWithSignInSynchronizor
    {
        void Update(ILearningRoomWithSignIn learningRoom);
    }
}

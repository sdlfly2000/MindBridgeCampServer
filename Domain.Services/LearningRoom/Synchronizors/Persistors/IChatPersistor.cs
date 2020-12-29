using Domain.LearningRoom;

namespace Domain.Services.LearningRoom.Synchronizors.Persistors
{
    public interface IChatPersistor
    {
        void Add(IChatAspect aspect);

        void Update(IChatAspect aspect);
    }
}

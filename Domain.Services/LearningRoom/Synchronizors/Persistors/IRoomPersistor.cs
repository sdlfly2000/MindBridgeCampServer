using Domain.LearningRoom;

namespace Domain.Services.LearningRoom.Synchronizors.Persistors
{
    public interface IRoomPersistor
    {
        void Add(IRoomAspect roomAspect);

        void Update(IRoomAspect roomAspect);
    }
}

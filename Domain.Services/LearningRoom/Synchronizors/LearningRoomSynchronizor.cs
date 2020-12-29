using Common.Core.DependencyInjection;
using Domain.LearningRoom;
using Domain.Services.LearningRoom.Synchronizors.Persistors;
using Infrastructure.Data.Sql.Persistence;

namespace Domain.Services.LearningRoom.Synchronizors
{
    [ServiceLocate(typeof(ILearningRoomSynchronizor))]
    public class LearningRoomSynchronizor : ILearningRoomSynchronizor
    {
        private readonly IRoomPersistor _roomPersistor;
        private readonly IPersistence _persistence;

        public LearningRoomSynchronizor(
            IRoomPersistor roomPersistor,
            IPersistence persistence)
        {
            _roomPersistor = roomPersistor;
            _persistence = persistence;
        }

        public void Add(ILearningRoom learningRoom)
        {
            _roomPersistor.Add(learningRoom);
            _persistence.Complete();
        }

        public void Update(ILearningRoom learningRoom)
        {
            _roomPersistor.Update(learningRoom);
            _persistence.Complete();
        }
    }
}

using Common.Core.DependencyInjection;
using Domain.LearningRoom;
using Infrastructure.Data.Sql.LearningRoom.Entities;
using Infrastructure.Data.Sql.Persistence.UnitOfWork;

namespace Domain.Services.LearningRoom.Synchronizors.Persistors
{
    [ServiceLocate(typeof(IRoomPersistor))]
    public class RoomPersistor : IRoomPersistor
    {
        private readonly IUnitOfWork<RoomEntity> _uow;

        public RoomPersistor(IUnitOfWork<RoomEntity> uow)
        {
            _uow = uow;
        }

        public void Add(IRoomAspect roomAspect)
        {
            if (roomAspect == null)
            {
                return;
            }

            _uow.Add(Map(roomAspect));
        }

        public void Update(IRoomAspect roomAspect)
        {
            if (roomAspect == null)
            {
                return;
            }

            _uow.Persist(Map(roomAspect));
        }

        #region Private Methods

        private RoomEntity Map(IRoomAspect roomAspect)
        {
            return new RoomEntity
            {
                roomId = roomAspect.Reference.Code,
                title = roomAspect.Title,
                learningContent = roomAspect.LearningContent,
                startDate = roomAspect.StartDate,
                endDate = roomAspect.EndDate,
                participantCount = roomAspect.ParticipantCount,
                place = roomAspect.Place,
                CreatedBy = roomAspect.CreatedBy.Code,
                CreatedOn = roomAspect.CreatedOn
            };
        }

        #endregion
    }
}

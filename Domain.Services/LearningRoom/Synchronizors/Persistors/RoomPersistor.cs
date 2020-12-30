using Common.Core.DependencyInjection;
using Domain.LearningRoom;
using Infrastructure.Data.Sql.LearningRoom.Entities;
using Infrastructure.Data.Sql.Persistence.UnitOfWork;

namespace Domain.Services.LearningRoom.Synchronizors.Persistors
{
    using Infrastructure.Data.Sql.Persistence;

    [ServiceLocate(typeof(IRoomPersistor))]
    public class RoomPersistor : Persistor<IRoomAspect, RoomEntity>, IRoomPersistor
    {
        public RoomPersistor(IUnitOfWork<RoomEntity> uow)
            : base(uow)
        {
        }

        protected override RoomEntity Map(IRoomAspect roomAspect)
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
    }
}

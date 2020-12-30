using Common.Core.DependencyInjection;
using Domain.LearningRoom;
using Infrastructure.Data.Sql.LearningRoom.Entities;
using Infrastructure.Data.Sql.Persistence.UnitOfWork;

namespace Domain.Services.LearningRoom.Synchronizors.Persistors
{
    using Infrastructure.Data.Sql.Persistence;

    [ServiceLocate(typeof(IParticipantPersistor))]
    public class ParticipantPersistor : Persistor<IParticipant, ParticipantEntity>, IParticipantPersistor
    {
        public ParticipantPersistor(IUnitOfWork<ParticipantEntity> uow)
            : base(uow)
        {
        }

        protected override ParticipantEntity Map(IParticipant participant)
        {
            return new ParticipantEntity
            {
                participantId = participant.Reference.Code,
                roomId = participant.Room.Code,
                userId = participant.User.Code,
                isDeleted = participant.IsDeleted
            };
        }


    }
}

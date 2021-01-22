using Common.Core.DependencyInjection;
using Domain.LearningRoom;
using Infrastructure.Data.Sql.LearningRoom.Entities;
using Common.Core.Data.Sql;

namespace Domain.Services.LearningRoom.Synchronizors.Persistors
{
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

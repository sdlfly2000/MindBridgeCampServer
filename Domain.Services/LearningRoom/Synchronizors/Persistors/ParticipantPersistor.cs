using Common.Core.DependencyInjection;
using Domain.LearningRoom;
using Infrastructure.Data.Sql.LearningRoom.Entities;
using Infrastructure.Data.Sql.Persistence.UnitOfWork;

namespace Domain.Services.LearningRoom.Synchronizors.Persistors
{
    [ServiceLocate(typeof(IParticipantPersistor))]
    public class ParticipantPersistor : IParticipantPersistor
    {
        private readonly IUnitOfWork<ParticipantEntity> _uow;

        public ParticipantPersistor(IUnitOfWork<ParticipantEntity> uow)
        {
            _uow = uow;
        }

        public void Add(IParticipant participant)
        {
            _uow.Add(Map(participant));
        }

        public void Update(IParticipant participant)
        {
            _uow.Persist(Map(participant));
        }

        #region Private Methods

        private ParticipantEntity Map(IParticipant participant)
        {
            return new ParticipantEntity
            {
                participantId = participant.Reference.Code,
                roomId = participant.Room.Code,
                userId = participant.User.Code,
                isDeleted = participant.IsDeleted
            };
        }

        #endregion
    }
}

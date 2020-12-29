using Common.Core.DependencyInjection;
using Domain.LearningRoom;
using Infrastructure.Data.Sql.LearningRoom.Entities;
using Infrastructure.Data.Sql.Persistence.UnitOfWork;

namespace Domain.Services.LearningRoom.Synchronizors.Persistors
{
    [ServiceLocate(typeof(ISignInPersistor))]
    public class SignInPersistor : ISignInPersistor
    {
        private readonly IUnitOfWork<SignInEntity> _uow;

        public SignInPersistor(IUnitOfWork<SignInEntity> uow)
        {
            _uow = uow;
        }

        public void Add(ISignInAspect aspect)
        {
            _uow.Add(Map(aspect));
        }

        public void Update(ISignInAspect aspect)
        {
            _uow.Persist(Map(aspect));
        }

        #region Private Methods

        private SignInEntity Map(ISignInAspect aspect)
        {
            return new SignInEntity
            {
                signInId = aspect.Reference.Code,
                signInOn = aspect.SignInOn,
                participant = aspect.Participant.Code,
                roomId = aspect.Room.Code
            };
        }

        #endregion
    }
}

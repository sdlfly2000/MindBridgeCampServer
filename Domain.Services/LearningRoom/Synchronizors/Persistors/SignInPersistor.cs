using Common.Core.DependencyInjection;
using Domain.LearningRoom;
using Infrastructure.Data.Sql.LearningRoom.Entities;
using Infrastructure.Data.Sql.Persistence.UnitOfWork;
using Infrastructure.Data.Sql.Persistence;

namespace Domain.Services.LearningRoom.Synchronizors.Persistors
{
    [ServiceLocate(typeof(ISignInPersistor))]
    public class SignInPersistor : Persistor<ISignInAspect, SignInEntity>, ISignInPersistor
    {
        public SignInPersistor(IUnitOfWork<SignInEntity> uow) 
            : base(uow)
        {
        }

        protected override SignInEntity Map(ISignInAspect aspect)
        {
            return new SignInEntity
            {
                signInId = aspect.Reference.Code,
                signInOn = aspect.SignInOn,
                participant = aspect.Participant.Code,
                roomId = aspect.Room.Code
            };
        }
    }
}

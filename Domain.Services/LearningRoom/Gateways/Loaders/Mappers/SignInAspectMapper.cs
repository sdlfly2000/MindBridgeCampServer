using Common.Core.DependencyInjection;
using Domain.LearningRoom;
using Domain.User;
using Infrastructure.Data.Sql.LearningRoom.Entities;

namespace Domain.Services.LearningRoom.Gateways.Loaders.Mappers
{
    [ServiceLocate(typeof(ISignInAspectMapper))]
    public class SignInAspectMapper : ISignInAspectMapper
    {
        public ISignInAspect Map(SignInEntity entity)
        {
            return new SignInAspect
            {
                Participant = new UserReference(entity.participant),
                Reference = new SignInReference(entity.signInId),
                Room = new RoomReference(entity.roomId),
                SignInOn = entity.signInOn
            };
        }
    }
}

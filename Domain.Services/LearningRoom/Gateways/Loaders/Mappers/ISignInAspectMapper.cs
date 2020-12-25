using Domain.LearningRoom;
using Infrastructure.Data.Sql.LearningRoom.Entities;

namespace Domain.Services.LearningRoom.Gateways.Loaders.Mappers
{
    public interface ISignInAspectMapper
    {
        ISignInAspect Map(SignInEntity entity);
    }
}

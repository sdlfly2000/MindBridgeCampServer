using Domain.User;
using Infrastructure.Data.Sql.User.Entities;

namespace Domain.Services.User.Loaders.Mappers
{
    public interface IUserAspectMapper
    {
        IUserAspect Map(UserEntity entity);
    }
}

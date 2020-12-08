using Infrastructure.Data.Sql.User.Entities;

namespace Infrastructure.Data.Sql.User.Repositories
{
    public interface IUserRepository
    {
        UserEntity FindByGuid(string guid);
    }
}

using Infrastructure.Data.Sql.User.Entities;

namespace Infrastructure.Data.Sql.User.Repositories
{
    public interface IUserInfoRepository
    {
        UserInfoEntity FindByGuid(string guid);
    }
}

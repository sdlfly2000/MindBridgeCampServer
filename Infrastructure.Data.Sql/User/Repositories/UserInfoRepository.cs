using Common.Core.DependencyInjection;
using Infrastructure.Data.Sql.User.Entities;
using System.Linq;

namespace Infrastructure.Data.Sql.User.Repositories
{
    [ServiceLocate(typeof(IUserInfoRepository))]
    public class UserInfoRepository : IUserInfoRepository
    {
        private IMindBridgeCampDbContext _context;

        public UserInfoRepository(IMindBridgeCampDbContext context)
        {
            _context = context;
        }

        public UserInfoEntity FindByGuid(string guid)
        {
            return FindAll().FirstOrDefault(u => u.openId.Equals(guid));
        }

        private IQueryable<UserInfoEntity> FindAll()
        {
            return _context.UserInfos.AsQueryable();
        }

    }
}

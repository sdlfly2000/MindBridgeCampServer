using Common.Core.DependencyInjection;
using Infrastructure.Data.Sql.User.Entities;
using System;
using System.Linq;

namespace Infrastructure.Data.Sql.User.Repositories
{
    [ServiceLocate(typeof(IUserRepository))]
    public class UserRepository : IUserRepository
    {
        private readonly IMindBridgeCampDbContext _context;

        public UserRepository(IMindBridgeCampDbContext context)
        {
            _context = context;
        }

        private IQueryable<UserEntity> FindAll()
        {
            return _context.Users.AsQueryable();
        }

        public UserEntity FindByGuid(string guid)
        {
            return FindAll().FirstOrDefault(u => u.userId.Equals(guid));
        }
    }
}

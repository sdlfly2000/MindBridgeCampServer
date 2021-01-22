using Common.Core.Data.Sql;
using Common.Core.DependencyInjection;
using Domain.Services.User.Synchronizers.Persistors;
using Domain.User;
using Microsoft.Extensions.Caching.Memory;

namespace Domain.Services.User.Synchronizers
{
    [ServiceLocate(typeof(IUserSynchronizer))]
    public class UserSynchronizer : IUserSynchronizer
    {
        private readonly IUserPersistor _userPersistor;
        private readonly IMemoryCache _memoryCache;
        private readonly IPersistence _persistence;

        public UserSynchronizer(
            IUserPersistor userPersistor,
            IPersistence persistence,
            IMemoryCache memoryCache)
        {
            _userPersistor = userPersistor;
            _persistence = persistence;
            _memoryCache = memoryCache;
        }

        public void Add(IUser user)
        {
            _userPersistor.Add(user);
            _persistence.Complete();         
        }

        public void Synchronize(IUser user)
        {
            _userPersistor.Update(user);
            _persistence.Complete();
            _memoryCache.Remove(user.UserId.CacheCode);
        }
    }
}

using Common.Core.DependencyInjection;
using Domain.Services.User.Synchronizers.Persistors;
using Domain.User;
using Infrastructure.Data.Sql.Persistence;
using Microsoft.Extensions.Caching.Memory;

namespace Domain.Services.User.Synchronizers
{
    [ServiceLocate(typeof(IUserInfoSynchronizer))]
    public class UserInfoSynchronizer : IUserInfoSynchronizer
    {
        private readonly IUserInfoPersistor _userInfoPersistor;
        private readonly IMemoryCache _memoryCache;
        private readonly IPersistence _persistence;

        public UserInfoSynchronizer(
            IUserInfoPersistor userInfoPersistor,
            IPersistence persistence,
            IMemoryCache memoryCache) 
        {
            _userInfoPersistor = userInfoPersistor;
            _persistence = persistence;
            _memoryCache = memoryCache;
        }

        public void Add(IUser user)
        {
            _userInfoPersistor.Add(user);
            _persistence.Complete();
        }

        public void Sychronize(IUser user)
        {
            _userInfoPersistor.Update(user);
            _persistence.Complete();
            _memoryCache.Remove(user.OpenId.CacheCode);
        }
    }
}

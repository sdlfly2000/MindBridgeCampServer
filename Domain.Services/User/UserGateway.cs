using Common.Core.DependencyInjection;
using Domain.Services.User.Loaders;
using Domain.Services.User.Synchronizers;
using Domain.User;
using Infrastructure.Data.Sql.Persistence;
using Microsoft.Extensions.Caching.Memory;

namespace Domain.Services.User
{
    [ServiceLocate(typeof(IUserGateway))]
    public class UserGateway : IUserGateway
    {
        private readonly IUserAspectLoader _userAspctLoader;
        private readonly IUserInfoAspectLoader _userInfoAspectLoader;
        private readonly IUserInfoSynchronizer _userInfoSynchronizer;
        private readonly IUserSynchronizer _userSynchronizer;
        private readonly IPersistence _persistence;
        private readonly IMemoryCache _memoryCache;

        public UserGateway(
            IUserAspectLoader userAspctLoader,
            IUserInfoAspectLoader userInfoAspectLoader,
            IUserInfoSynchronizer userInfoSynchronizer,
            IUserSynchronizer userSynchronizer,
            IPersistence persistence,
            IMemoryCache memoryCache)
        {
            _userAspctLoader = userAspctLoader;
            _userInfoAspectLoader = userInfoAspectLoader;
            _userInfoSynchronizer = userInfoSynchronizer;
            _userSynchronizer = userSynchronizer;
            _persistence = persistence;
            _memoryCache = memoryCache;
        }

        public void Add(IUser user)
        {
            _userSynchronizer.Add(user);
            _userInfoSynchronizer.Add(user);
            _persistence.Complete();
        }

        public IUser Load(string userId)
        {
            return new UserDomain(
                _userAspctLoader.Load(new UserReference(userId, "UserAspect")),
                _userInfoAspectLoader.Load(new UserReference(userId, "UserInfoAspect")));
        }

        public void Save(IUser user)
        {
            _userSynchronizer.Synchronize(user);
            _userInfoSynchronizer.Sychronize(user);
            _persistence.Complete();
            _memoryCache.Remove(user.UserId.CacheCode);
            _memoryCache.Remove(user.OpenId.CacheCode);
        }

        public void SaveUserInfo(IUser user)
        {
            _userInfoSynchronizer.Sychronize(user);
            _persistence.Complete();
            _memoryCache.Remove(user.OpenId.CacheCode);
        }
    }
}

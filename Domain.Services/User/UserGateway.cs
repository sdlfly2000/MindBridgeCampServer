using Common.Core.DependencyInjection;
using Domain.Services.User.Loaders;
using Domain.Services.User.Synchronizers;
using Domain.User;
using Infrastructure.Data.Sql.Persistence;

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

        public UserGateway(
            IUserAspectLoader userAspctLoader,
            IUserInfoAspectLoader userInfoAspectLoader,
            IUserInfoSynchronizer userInfoSynchronizer,
            IUserSynchronizer userSynchronizer,
            IPersistence persistence)
        {
            _userAspctLoader = userAspctLoader;
            _userInfoAspectLoader = userInfoAspectLoader;
            _userInfoSynchronizer = userInfoSynchronizer;
            _userSynchronizer = userSynchronizer;
            _persistence = persistence;
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
                _userAspctLoader.Load("User" + userId),
                _userInfoAspectLoader.Load(userId));
        }

        public void Save(IUser user)
        {
            _userSynchronizer.Synchronize(user);
            _userInfoSynchronizer.Sychronize(user);
            _persistence.Complete();
        }
    }
}

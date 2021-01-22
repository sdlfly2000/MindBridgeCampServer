using Common.Core.DependencyInjection;
using Domain.Services.User.Gateways.Loaders;
using Domain.Services.User.Synchronizers;
using Domain.User;

namespace Domain.Services.User
{
    [ServiceLocate(typeof(IUserGateway))]
    public class UserGateway : IUserGateway
    {
        private readonly IUserAspectLoader _userAspctLoader;
        private readonly IUserInfoAspectLoader _userInfoAspectLoader;
        private readonly IUserInfoSynchronizer _userInfoSynchronizer;
        private readonly IUserSynchronizer _userSynchronizer;

        public UserGateway(
            IUserAspectLoader userAspctLoader,
            IUserInfoAspectLoader userInfoAspectLoader,
            IUserInfoSynchronizer userInfoSynchronizer,
            IUserSynchronizer userSynchronizer)
        {
            _userAspctLoader = userAspctLoader;
            _userInfoAspectLoader = userInfoAspectLoader;
            _userInfoSynchronizer = userInfoSynchronizer;
            _userSynchronizer = userSynchronizer;
        }

        public void Add(IUser user)
        {
            _userSynchronizer.Add(user);
            _userInfoSynchronizer.Add(user);
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
        }

        public void SaveUserInfo(IUser user)
        {
            _userInfoSynchronizer.Sychronize(user);
        }

        public void SaveUser(IUser user)
        {
            _userSynchronizer.Synchronize(user);
        }
    }
}

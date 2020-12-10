using Common.Core.DependencyInjection;
using Domain.Services.User.Loaders;
using Domain.User;

namespace Domain.Services.User
{
    [ServiceLocate(typeof(IUserGateway))]
    public class UserGateway : IUserGateway
    {
        private readonly IUserAspectLoader _userAspctLoader;
        private readonly IUserInfoAspectLoader _userInfoAspectLoader;

        public UserGateway(
            IUserAspectLoader userAspctLoader,
            IUserInfoAspectLoader userInfoAspectLoader)
        {
            _userAspctLoader = userAspctLoader;
            _userInfoAspectLoader = userInfoAspectLoader;
        }

        public IUser Load(string userId)
        {
            return new UserDomain(
                _userAspctLoader.Load(userId),
                _userInfoAspectLoader.Load(userId));
        }
    }
}

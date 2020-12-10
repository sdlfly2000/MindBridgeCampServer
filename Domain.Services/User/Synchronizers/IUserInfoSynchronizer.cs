using Domain.User;

namespace Domain.Services.User.Synchronizers
{
    public interface IUserInfoSynchronizer
    {
        void Sychronize(IUser user);
    }
}

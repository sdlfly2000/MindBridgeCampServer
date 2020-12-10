using Domain.User;

namespace Domain.Services.User.Synchronizers
{
    interface IUserSynchronizer
    {
        void Synchronize(IUser user);
    }
}

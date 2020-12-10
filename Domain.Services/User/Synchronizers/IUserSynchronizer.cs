using Domain.User;

namespace Domain.Services.User.Synchronizers
{
    public interface IUserSynchronizer
    {
        void Synchronize(IUser user);

        void Add(IUser user);
    }
}

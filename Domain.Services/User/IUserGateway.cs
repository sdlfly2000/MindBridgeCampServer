using Domain.User;

namespace Domain.Services.User
{
    public interface IUserGateway
    {
        IUser Load(string userId);

        void Add(IUser user);

        void Save(IUser user);

        void SaveUserInfo(IUser user);

        void SaveUser(IUser user);
    }
}

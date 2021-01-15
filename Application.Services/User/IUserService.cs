using Application.Services.User.Contracts;
using Application.User;

namespace Application.Services.User
{
    public interface IUserService
    {
        GetResponse Get(GetByIdRequest request);

        void Add(string loginToken, UserModel model);

        GetResponse Update(UserModel model);

        void UpdateUserInfo(string loginToken, UserModel model);

        void UpdateUser(string loginToken, UserModel model);

        bool IsUserExist(string loginToken);

        GetResponse Get(GetByLoginTokenRequest request);
    }
}

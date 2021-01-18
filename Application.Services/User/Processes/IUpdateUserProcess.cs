using Application.User;

namespace Application.Services.User.Processes
{
    public interface IUpdateUserProcess
    {
        void UpdateUserInfo(string loginToken, UserModel model);

        void UpdateUser(string loginToken, UserModel model);
    }
}

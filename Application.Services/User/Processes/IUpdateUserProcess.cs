using Application.Services.User.Contracts;
using Application.User;

namespace Application.Services.User.Processes
{
    public interface IUpdateUserProcess
    {
        GetResponse Update(UserModel model);
    }
}

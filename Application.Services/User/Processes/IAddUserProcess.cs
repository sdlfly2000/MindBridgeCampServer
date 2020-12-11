using Application.Services.User.Contracts;
using Application.User;

namespace Application.Services.User.Processes
{
    public interface IAddUserProcess
    {
        GetResponse Add(UserModel model);
    }
}

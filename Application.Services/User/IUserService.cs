using Application.Services.User.Contracts;

namespace Application.Services.User
{
    public interface IUserService
    {
        GetResponse Get(GetByIdRequest request);
    }
}

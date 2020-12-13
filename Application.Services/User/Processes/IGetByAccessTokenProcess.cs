using Application.Services.User.Contracts;

namespace Application.Services.User.Processes
{
    public interface IGetByAccessTokenProcess
    {
        GetResponse GetByToken(string accessToken);
    }
}

using Domain.LoginToken;

namespace Domain.Services.LoginToken
{
    public interface ILoginTokenGateway
    {
        ILoginToken Get(string accessToken);
    }
}

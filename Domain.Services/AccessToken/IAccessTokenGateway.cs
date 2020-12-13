using Domain.AccessToken;

namespace Domain.Services.AccessToken
{
    public interface IAccessTokenGateway
    {
        IAccessToken Get(string accessToken);
    }
}

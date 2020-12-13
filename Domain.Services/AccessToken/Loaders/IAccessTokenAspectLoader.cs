using Domain.AccessToken;

namespace Domain.Services.AccessToken.Loaders
{
    public interface IAccessTokenAspectLoader
    {
        IAccessToken Load(string accessToken);
    }
}

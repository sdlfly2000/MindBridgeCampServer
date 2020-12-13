using Infrastructure.Data.CacheAgent.AccessToken.Entities;

namespace Infrastructure.Data.CacheAgent.AccessToken
{
    public interface IAccessTokenCacheAgent
    {
        AccessTokenEntity Get(string accessToken);
    }
}

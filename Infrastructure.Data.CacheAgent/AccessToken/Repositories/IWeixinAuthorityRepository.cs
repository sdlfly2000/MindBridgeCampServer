using Infrastructure.Data.CacheAgent.AccessToken.Entities;

namespace Infrastructure.Data.CacheAgent.AccessToken.Repositories
{
    public interface IWeixinAuthorityRepository
    {
        WeixinAuthorityEntity Find(string key);
    }
}

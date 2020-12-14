using Infrastructure.Data.CacheAgent.LoginToken.Entities;

namespace Infrastructure.Data.CacheAgent.LoginToken.Repositories
{
    public interface IWeixinAuthorityRepository
    {
        WeixinAuthorityEntity Find(string key);
    }
}

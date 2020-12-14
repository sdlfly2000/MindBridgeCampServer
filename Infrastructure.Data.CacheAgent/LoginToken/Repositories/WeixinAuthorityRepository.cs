using Common.Core.DependencyInjection;
using Infrastructure.Data.CacheAgent.LoginToken.Entities;

namespace Infrastructure.Data.CacheAgent.LoginToken.Repositories
{
    [ServiceLocate(typeof(IWeixinAuthorityRepository))]
    public class WeixinAuthorityRepository : IWeixinAuthorityRepository
    {
        private readonly ICacheAgent<WeixinAuthorityEntity> _cacheAgent;

        public WeixinAuthorityRepository(ICacheAgent<WeixinAuthorityEntity> cacheAgent)
        {
            _cacheAgent = cacheAgent;
        }

        public WeixinAuthorityEntity Find(string key)
        {
            return _cacheAgent.Get<WeixinAuthorityEntity>(key);
        }
    }
}

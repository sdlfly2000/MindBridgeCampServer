using Common.Core.DependencyInjection;
using Infrastructure.Data.CacheAgent.AccessToken.Entities;

namespace Infrastructure.Data.CacheAgent.AccessToken.Repositories
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

using Domain.AccessToken;
using Infrastructure.Data.CacheAgent.AccessToken.Entities;

namespace Domain.Services.AccessToken.Loaders.Mappers
{
    public interface IAccessTokenAspectMapper
    {
        IAccessTokenAspect Map(WeixinAuthorityEntity entity);
    }
}

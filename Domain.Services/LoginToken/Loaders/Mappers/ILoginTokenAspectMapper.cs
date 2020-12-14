using Domain.LoginToken;
using Infrastructure.Data.CacheAgent.AccessToken.Entities;

namespace Domain.Services.LoginToken.Loaders.Mappers
{
    public interface ILoginTokenAspectMapper
    {
        ILoginTokenAspect Map(WeixinAuthorityEntity entity);
    }
}

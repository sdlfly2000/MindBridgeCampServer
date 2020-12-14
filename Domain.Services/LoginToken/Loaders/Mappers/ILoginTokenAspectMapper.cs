using Domain.LoginToken;
using Infrastructure.Data.CacheAgent.LoginToken.Entities;

namespace Domain.Services.LoginToken.Loaders.Mappers
{
    public interface ILoginTokenAspectMapper
    {
        ILoginTokenAspect Map(WeixinAuthorityEntity entity);
    }
}

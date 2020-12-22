using Domain.AccessToken;
using Common.Core.DependencyInjection;
using Domain.LoginToken;
using Infrastructure.Data.CacheAgent.LoginToken.Entities;
using Domain.User;

namespace Domain.Services.LoginToken.Loaders.Mappers
{
    [ServiceLocate(typeof(ILoginTokenAspectMapper))]
    public class LoginTokenAspectMapper : ILoginTokenAspectMapper
    {
        public ILoginTokenAspect Map(WeixinAuthorityEntity entity)
        {
            return new LoginTokenAspect
            {
                AccessTokenCode = entity.LoginToken.ToString(),
                OpenId = new UserReference(entity.OpenId),
                SessionKey = entity.SessionKey
            };
        }
    }
}

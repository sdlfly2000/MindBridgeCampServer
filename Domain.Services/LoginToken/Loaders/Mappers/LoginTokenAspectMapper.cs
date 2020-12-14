using Domain.AccessToken;
using System;
using Infrastructure.Data.CacheAgent.AccessToken.Entities;
using Common.Core.DependencyInjection;
using Domain.LoginToken;

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
                OpenId = new OpenIdReference(Guid.Parse(entity.OpenId)),
                SessionKey = entity.SessionKey
            };
        }
    }
}

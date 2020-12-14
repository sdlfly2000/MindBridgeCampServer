using Domain.AccessToken;
using System;
using Common.Core.DependencyInjection;
using Domain.LoginToken;
using Infrastructure.Data.CacheAgent.LoginToken.Entities;

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
                OpenId = new OpenIdReference(entity.OpenId),
                SessionKey = entity.SessionKey
            };
        }
    }
}

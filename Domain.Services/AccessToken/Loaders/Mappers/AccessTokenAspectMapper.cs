using Domain.AccessToken;
using System;

namespace Domain.Services.AccessToken.Loaders.Mappers
{
    using Infrastructure.Data.CacheAgent.AccessToken.Entities;

    public class AccessTokenAspectMapper : IAccessTokenAspectMapper
    {
        public IAccessTokenAspect Map(WeixinAuthorityEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}

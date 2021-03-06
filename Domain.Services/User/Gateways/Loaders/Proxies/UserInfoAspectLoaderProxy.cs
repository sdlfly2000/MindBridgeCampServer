﻿using Common.Core.AOP;
using Common.Core.DependencyInjection;
using Domain.Services.User.Gateways.Loaders.Mappers;
using Domain.User;
using Infrastructure.Data.Sql.User.Repositories;
using Microsoft.Extensions.Caching.Memory;
using System.Reflection;

namespace Domain.Services.User.Gateways.Loaders.Proxies
{
    [ServiceLocate(typeof(IUserInfoAspectLoader))]
    public class UserInfoAspectLoaderProxy : IUserInfoAspectLoader
    {
        private UserInfoAspectLoader _userInfoAspectLoader;
        private IUserInfoAspectLoader _userInfoAspectLoaderDecorator;

        public UserInfoAspectLoaderProxy(
            IUserInfoAspectMapper userInfoAspectMapper,
            IUserInfoRepository userInfoRepository,
            IMemoryCache memoryCache)
        {
            _userInfoAspectLoader = new UserInfoAspectLoader(userInfoAspectMapper, userInfoRepository);

            _userInfoAspectLoaderDecorator = DispatchProxy.Create<IUserInfoAspectLoader, CacheProxy>();
            ((CacheProxy)_userInfoAspectLoaderDecorator).Wrapped = _userInfoAspectLoader;
            ((CacheProxy)_userInfoAspectLoaderDecorator).CacheAction = new CacheAction<IUserInfoAspect, UserReference>(memoryCache);
        }

        public IUserInfoAspect Load(UserReference reference)
        {
            return _userInfoAspectLoaderDecorator.Load(reference);
        }
    }
}

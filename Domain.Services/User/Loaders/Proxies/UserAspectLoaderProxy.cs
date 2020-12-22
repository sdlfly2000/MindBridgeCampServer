using Common.Core.AOP;
using Common.Core.DependencyInjection;
using Domain.Services.User.Loaders.Mappers;
using Domain.User;
using Infrastructure.Data.Sql.User.Repositories;
using Microsoft.Extensions.Caching.Memory;
using System.Reflection;

namespace Domain.Services.User.Loaders.Proxies
{
    [ServiceLocate(typeof(IUserAspectLoader))]
    public class UserAspectLoaderProxy : IUserAspectLoader
    {
        private UserAspectLoader _userAspectLoader;
        private IUserAspectLoader _userAspectLoaderDecorator;

        public UserAspectLoaderProxy(
            IUserAspectMapper userAspectMapper,
            IUserRepository userRepository,
            IMemoryCache memoryCache)
        {
            _userAspectLoader = new UserAspectLoader(userAspectMapper, userRepository);

            _userAspectLoaderDecorator = DispatchProxy.Create<IUserAspectLoader, CacheProxy>();
            ((CacheProxy)_userAspectLoaderDecorator).Wrapped = _userAspectLoader;
            ((CacheProxy)_userAspectLoaderDecorator).CacheAction = new CacheAction<IUserAspect, UserReference>(memoryCache);
        }

        public IUserAspect Load(UserReference reference)
        {
            return _userAspectLoaderDecorator.Load(reference);
        }
    }
}

using Common.Core.DependencyInjection;
using Domain.Services.User.Loaders.Mappers;
using Domain.User;
using Infrastructure.Data.Sql.User.Repositories;

namespace Domain.Services.User.Loaders
{
    [ServiceLocate(typeof(IUserAspectLoader))]
    public class UserAspectLoader : IUserAspectLoader
    {
        private readonly IUserAspectMapper _userAspectMapper;
        private readonly IUserRepository _userRepository;

        public UserAspectLoader(
            IUserAspectMapper userAspectMapper,
            IUserRepository userRepository)
        {
            _userAspectMapper = userAspectMapper;
            _userRepository = userRepository;
        }

        public IUserAspect Load(string userId)
        {
            return _userAspectMapper.Map(_userRepository.FindByGuid(userId));
        }
    }
}

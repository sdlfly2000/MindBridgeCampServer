using Domain.Services.User.Gateways.Loaders.Mappers;
using Domain.User;
using Infrastructure.Data.Sql.User.Repositories;

namespace Domain.Services.User.Gateways.Loaders
{
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

        public IUserAspect Load(UserReference reference)
        {
            return _userAspectMapper.Map(_userRepository.FindByGuid(reference.Code));
        }
    }
}

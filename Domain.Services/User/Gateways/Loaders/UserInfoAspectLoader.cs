using Domain.Services.User.Gateways.Loaders.Mappers;
using Domain.User;
using Infrastructure.Data.Sql.User.Repositories;

namespace Domain.Services.User.Gateways.Loaders
{
    public class UserInfoAspectLoader : IUserInfoAspectLoader
    {
        private readonly IUserInfoAspectMapper _userInfoAspectMapper;
        private readonly IUserInfoRepository _userInfoRepository;

        public UserInfoAspectLoader(
            IUserInfoAspectMapper userInfoAspectMapper,
            IUserInfoRepository userInfoRepository)
        {
            _userInfoAspectMapper = userInfoAspectMapper;
            _userInfoRepository = userInfoRepository;
        }

        public IUserInfoAspect Load(UserReference reference)
        {
            return _userInfoAspectMapper.Map(_userInfoRepository.FindByGuid(reference.Code));
        }
    }
}

using Common.Core.DependencyInjection;
using Domain.Services.User.Gateways.Loaders.Mappers;
using Domain.User;
using Infrastructure.Data.Sql.User.Entities;

namespace Domain.Services.User.Loaders.Mappers
{
    [ServiceLocate(typeof(IUserInfoAspectMapper))]
    public class UserInfoAspectMapper : IUserInfoAspectMapper
    {
        public IUserInfoAspect Map(UserInfoEntity entity)
        {
            return new UserInfoAspect
            {
                OpenId = new UserReference(entity.openId, "UserInfoAspect"),
                AvatarUrl = entity.avatarUrl,
                City = entity.city,
                Country = entity.country,
                Language = entity.language,
                NickName = entity.nickName,
                Province = entity.province
            };
        }
    }
}

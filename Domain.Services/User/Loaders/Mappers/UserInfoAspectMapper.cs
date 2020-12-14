using Common.Core.DependencyInjection;
using Domain.LoginToken;
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
                OpenId = new OpenIdReference(entity.openId),
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

using Common.Core.Data.Sql;
using Common.Core.DependencyInjection;
using Domain.User;
using Infrastructure.Data.Sql.User.Entities;

namespace Domain.Services.User.Synchronizers.Persistors
{
    [ServiceLocate(typeof(IUserInfoPersistor))]
    public class UserInfoPersistor : Persistor<IUserInfoAspect, UserInfoEntity>, IUserInfoPersistor
    {
        public UserInfoPersistor(IUnitOfWork<UserInfoEntity> uow)
            : base(uow)
        {
        }

        protected override UserInfoEntity Map(IUserInfoAspect aspect)
        {
            return new UserInfoEntity
            {
                openId = aspect.OpenId.Code,
                avatarUrl = aspect.AvatarUrl,
                city = aspect.City,
                country = aspect.Country,
                language = aspect.Language,
                nickName = aspect.NickName,
                province = aspect.Province
            };
        }
    }
}

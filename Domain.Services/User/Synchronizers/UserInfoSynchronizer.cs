using Common.Core.DependencyInjection;
using Domain.User;
using Infrastructure.Data.Sql.Persistence.UnitOfWork;
using Infrastructure.Data.Sql.User.Entities;
using System;

namespace Domain.Services.User.Synchronizers
{
    [ServiceLocate(typeof(IUserInfoSynchronizer))]
    public class UserInfoSynchronizer : IUserInfoSynchronizer
    {
        private readonly IUnitOfWork<UserInfoEntity> _uow;

        public UserInfoSynchronizer(IUnitOfWork<UserInfoEntity> uow) 
        {
            _uow = uow;
        }

        public void Add(IUser user)
        {
            if (user.OpenId.Equals(Guid.Empty))
            { 
                return; 
            }

            var entity = new UserInfoEntity
            {
                openId = user.OpenId,
                avatarUrl = user.AvatarUrl,
                city = user.City,
                country = user.City,
                language = user.Language,
                nickName = user.NickName,
                province = user.Province
            };

            _uow.Add(entity);            
        }

        public void Sychronize(IUser user)
        {
            if (user.OpenId.Equals(Guid.Empty))
            {
                return;
            }

            var entity = new UserInfoEntity
            {
                openId = user.OpenId,
                avatarUrl = user.AvatarUrl,
                city = user.City,
                country = user.City,
                language = user.Language,
                nickName = user.NickName,
                province = user.Province
            };

            _uow.Persist<UserInfoEntity>(entity);            
        }
    }
}

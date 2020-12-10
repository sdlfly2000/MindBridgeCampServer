using Common.Core.DependencyInjection;
using Domain.User;
using Infrastructure.Data.Sql.Persistence.UnitOfWork;
using Infrastructure.Data.Sql.User.Entities;
using System;

namespace Domain.Services.User.Synchronizers
{
    [ServiceLocate(typeof(IUserSynchronizer))]
    public class UserSynchronizer : IUserSynchronizer
    {
        private readonly IUnitOfWork<UserEntity> _uow;

        public UserSynchronizer(IUnitOfWork<UserEntity> uow)
        {
            _uow = uow;
        }

        public void Synchronize(IUser user)
        {
            var entity = new UserEntity 
            {

            };

            _uow.Persist<UserEntity>(entity);
        }
    }
}

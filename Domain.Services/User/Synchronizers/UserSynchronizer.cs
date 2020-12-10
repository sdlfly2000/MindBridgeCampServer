using Common.Core.DependencyInjection;
using Domain.User;
using Infrastructure.Data.Sql.Persistence.UnitOfWork;
using Infrastructure.Data.Sql.User.Entities;
using System;
using System.Linq;

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

        public void Add(IUser user)
        {
            var entity = new UserEntity
            {
                userId = user.UserId,
                expectationAfterGraduation = user.ExpectationAfterGraduation,
                gender = (int?)user.Gender,
                height = user.Height,
                majorIn = user.MajorIn,
                name = user.Name,
                studyContent = user.StudyContent,
                weight = user.Weight,
                hobbies = user.Hobbies.Select(hobby => new HobbyEntity
                {
                    hobbyId = hobby.id,
                    name = hobby.name
                }).ToList()
            };

            _uow.Add(entity);
        }

        public void Synchronize(IUser user)
        {
            var entity = new UserEntity
            {
                userId = user.UserId,
                expectationAfterGraduation = user.ExpectationAfterGraduation,
                gender = (int?)user.Gender,
                height = user.Height,
                majorIn = user.MajorIn,
                name = user.Name,
                studyContent = user.StudyContent,
                weight = user.Weight,
                hobbies = user.Hobbies.Select(hobby => new HobbyEntity
                {
                    hobbyId = hobby.id,
                    name = hobby.name
                }).ToList()                
            };

            _uow.Persist(entity);
        }
    }
}

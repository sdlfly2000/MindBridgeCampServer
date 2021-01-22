using Common.Core.Data.Sql;
using Common.Core.DependencyInjection;
using Domain.User;
using Infrastructure.Data.Sql.User.Entities;

namespace Domain.Services.User.Synchronizers.Persistors
{
    [ServiceLocate(typeof(IUserPersistor))]
    public class UserPersistor : Persistor<IUserAspect, UserEntity>, IUserPersistor
    {
        public UserPersistor(IUnitOfWork<UserEntity> uow)
            : base(uow)
        {
        }

        protected override UserEntity Map(IUserAspect aspect)
        {
            return new UserEntity
            {
                userId = aspect.UserId.Code,
                expectationAfterGraduation = aspect.ExpectationAfterGraduation,
                gender = (int)aspect.Gender,
                height = aspect.Height,
                weight = aspect.Weight,
                hobby = aspect.Hobby,
                majorIn = aspect.MajorIn,
                name = aspect.Name,
                studyContent = aspect.StudyContent
            };
        }
    }
}

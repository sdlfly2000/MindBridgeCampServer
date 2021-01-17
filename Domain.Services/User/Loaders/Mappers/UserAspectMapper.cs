using Common.Core.DependencyInjection;
using Domain.User;
using Infrastructure.Data.Sql.User.Entities;

namespace Domain.Services.User.Loaders.Mappers
{
    [ServiceLocate(typeof(IUserAspectMapper))]
    public class UserAspectMapper : IUserAspectMapper
    {       
        public IUserAspect Map(UserEntity entity)
        {
            return new UserAspect
            {
                UserId = new UserReference(entity.userId, "UserAspect"),
                Gender = entity.gender.HasValue ? (GenderType)entity.gender : GenderType.Unknown,
                Name = entity.name,
                MajorIn = entity.majorIn,
                Height = entity.height,
                Weight = entity.weight,
                StudyContent = entity.studyContent,
                ExpectationAfterGraduation = entity.expectationAfterGraduation,
                Hobby = entity.hobby
            };
        }
    }
}

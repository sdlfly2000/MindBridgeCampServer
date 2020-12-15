using Common.Core.DependencyInjection;
using Domain.LoginToken;
using Domain.User;
using Infrastructure.Data.Sql.User.Entities;
using System.Linq;

namespace Domain.Services.User.Loaders.Mappers
{
    [ServiceLocate(typeof(IUserAspectMapper))]
    public class UserAspectMapper : IUserAspectMapper
    {       
        public IUserAspect Map(UserEntity entity)
        {
            return new UserAspect
            {
                UserId = new OpenIdReference(entity.userId),
                Gender = (GenderType)entity.gender,
                Name = entity.name,
                MajorIn = entity.majorIn,
                Height = entity.height,
                Weight = entity.weight,
                StudyContent = entity.studyContent,
                ExpectationAfterGraduation = entity.expectationAfterGraduation,
                //Hobbies = entity.hobbies.Select(h => new Hobby
                //{
                //    name = h.name,

                //}).ToList()
            };
        }
    }
}

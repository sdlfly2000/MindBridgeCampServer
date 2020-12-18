using Common.Core.DependencyInjection;
using Domain.LoginToken;
using Domain.User;
using Infrastructure.Data.Sql.User.Entities;
using System.Collections.Generic;
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
                Gender = entity.gender.HasValue ? (GenderType)entity.gender : GenderType.Unknown,
                Name = entity.name,
                MajorIn = entity.majorIn,
                Height = entity.height,
                Weight = entity.weight,
                StudyContent = entity.studyContent,
                ExpectationAfterGraduation = entity.expectationAfterGraduation,
                Hobbies = entity.hobbies == null 
                ? new List<Hobby>() 
                : entity.hobbies.Select(h => new Hobby
                {
                    Id = h.hobbyId,
                    Name = h.name,
                    IsActive = h.isActive
                }).ToList()
            };
        }
    }
}

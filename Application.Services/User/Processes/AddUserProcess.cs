using Application.Services.User.Contracts;
using Application.User;
using Common.Core.DependencyInjection;
using Domain.LoginToken;
using Domain.Services.User;
using Domain.User;
using System;
using System.Linq;

namespace Application.Services.User.Processes
{
    [ServiceLocate(typeof(IAddUserProcess))]
    public class AddUserProcess : IAddUserProcess
    {
        private readonly IUserGateway _userGateway;

        public AddUserProcess(IUserGateway userGateway)
        {
            _userGateway = userGateway;
        }

        public GetResponse Add(UserModel model)
        {
            var user = new UserDomain(
            new UserAspect
            {
                UserId = new OpenIdReference(model.UserId),
                ExpectationAfterGraduation = model.ExpectationAfterGraduation,
                Gender = model.Gender,
                Height = model.Height,
                Weight = model.Weight,
                MajorIn = model.MajorIn,
                Name = model.Name,
                StudyContent = model.StudyContent,
                Hobbies = model.Hobbies.Select(hobby => new Hobby
                {
                    Id = Guid.NewGuid(),
                    Name = hobby.Name,
                    IsActive = true
                }).ToList()
            },
            new UserInfoAspect
            {
                OpenId = new OpenIdReference(model.OpenId),
                NickName = model.NickName,
                AvatarUrl = model.AvatarUrl,
                City = model.City,
                Country = model.Country,
                Language = model.Language,
                Province = model.Province
            });

            _userGateway.Add(user);

            return new GetResponse();
        }
    }
}

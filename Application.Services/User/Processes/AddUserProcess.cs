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
    using Domain.Services.LoginToken;

    [ServiceLocate(typeof(IAddUserProcess))]
    public class AddUserProcess : IAddUserProcess
    {
        private readonly IUserGateway _userGateway;
        private readonly ILoginTokenGateway _loginTokenGateway;

        public AddUserProcess(
            IUserGateway userGateway,
            ILoginTokenGateway loginTokenGateway)
        {
            _userGateway = userGateway;
            _loginTokenGateway = loginTokenGateway;
        }

        public void Add(string loginToken, UserModel model)
        {
            var token = _loginTokenGateway.Get(loginToken);

            var user = new UserDomain(
            new UserAspect
            {
                UserId = new UserReference(token.OpenId.Code, "UserAspect"),
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
                OpenId = new UserReference(token.OpenId.Code, "UserInfo"),
                NickName = model.NickName,
                AvatarUrl = model.AvatarUrl,
                City = model.City,
                Country = model.Country,
                Language = model.Language,
                Province = model.Province
            });

            _userGateway.Add(user);
        }
    }
}

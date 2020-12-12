using Application.Services.User.Contracts;
using Application.User;
using Common.Core.DependencyInjection;
using Domain.Services.User;
using Domain.User;
using System;

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
            },
            new UserInfoAspect
            {
                OpenId = Guid.NewGuid(),
                NickName = model.NickName
            });

            _userGateway.Add(user);

            return new GetResponse();
        }
    }
}

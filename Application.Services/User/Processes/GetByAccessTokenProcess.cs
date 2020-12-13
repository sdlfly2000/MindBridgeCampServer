using Application.Services.User.Contracts;
using Common.Core.DependencyInjection;
using Domain.Services.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services.User.Processes
{
    [ServiceLocate(typeof(IGetByAccessTokenProcess))]
    public class GetByAccessTokenProcess : IGetByAccessTokenProcess
    {
        private readonly IUserGateway _userGateway;

        public GetByAccessTokenProcess(IUserGateway userGateway)
        {
            _userGateway = userGateway;
        }

        public GetResponse GetByToken(string accessToken)
        {
            throw new NotImplementedException();
        }
    }
}

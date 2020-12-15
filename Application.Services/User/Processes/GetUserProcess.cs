using Application.Services.User.Contracts;
using Common.Core.DependencyInjection;
using Domain.Services.LoginToken;
using Domain.Services.User;

namespace Application.Services.User.Processes
{
    [ServiceLocate(typeof(IGetUserProcess))]
    public class GetUserProcess : IGetUserProcess
    {
        private readonly IUserGateway _userGateway;
        private readonly ILoginTokenGateway _loginTokenGateway;

        public GetUserProcess(
            IUserGateway userGateway,
            ILoginTokenGateway loginTokenGateway)
        {
            _userGateway = userGateway;
            _loginTokenGateway = loginTokenGateway;
        }

        public GetResponse Get(GetByIdRequest request)
        {
             return new GetResponse
            {
                User = _userGateway.Load(request.UserId)
            };
        }

        public GetResponse Get(GetByLoginTokenRequest request)
        {
            var loginToken = _loginTokenGateway.Get(request.LoginToken);
            return new GetResponse
            {
                User = _userGateway.Load(loginToken.OpenId.Code)
            };
        }
    }
}

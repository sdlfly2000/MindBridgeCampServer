using Common.Core.DependencyInjection;
using Domain.Services.LoginToken;
using Domain.Services.User;

namespace Application.Services.User.Processes
{
    [ServiceLocate(typeof(ICheckUserExistanceProcess))]
    public class CheckUserExistanceProcess : ICheckUserExistanceProcess
    {
        private readonly ILoginTokenGateway _loginTokenGateway;
        private readonly IUserGateway _userGateway;

        public CheckUserExistanceProcess(
            ILoginTokenGateway loginTokenGateway,
            IUserGateway userGateway)
        {
            _loginTokenGateway = loginTokenGateway;
            _userGateway = userGateway;
        }

        public bool IsUserExist(string loginToken)
        {
            var login = _loginTokenGateway.Get(loginToken);

            var user = _userGateway.Load(login.OpenId.Code);

            return user != null;
        }
    }
}

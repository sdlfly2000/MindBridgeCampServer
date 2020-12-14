using Common.Core.DependencyInjection;
using Domain.LoginToken;
using Domain.Services.LoginToken.Loaders;

namespace Domain.Services.LoginToken
{
    [ServiceLocate(typeof(ILoginTokenGateway))]
    public class LoginTokenGateway : ILoginTokenGateway
    {
        private readonly ILoginTokenAspectLoader _loginTokenAspectLoader;

        public LoginTokenGateway(ILoginTokenAspectLoader loginTokenAspectLoader)
        {
            _loginTokenAspectLoader = loginTokenAspectLoader;
        }

        public ILoginToken Get(string loginToken)
        {
            var loginTokenAspect = _loginTokenAspectLoader.Load(loginToken);

            return new LoginTokenDomain(loginTokenAspect);
        }
    }
}

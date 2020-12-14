using Domain.LoginToken;
using System;

namespace Domain.Services.LoginToken
{
    public class LoginTokenGateway : ILoginTokenGateway
    {
        public ILoginToken Get(string accessToken)
        {
            throw new NotImplementedException();
        }
    }
}

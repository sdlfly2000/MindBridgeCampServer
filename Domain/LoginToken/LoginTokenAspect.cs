using Domain.LoginToken;
using Domain.User;

namespace Domain.AccessToken
{
    public class LoginTokenAspect : ILoginTokenAspect
    {
        public UserReference OpenId { get; set; }

        public string SessionKey { get; set; }

        public string AccessTokenCode { get; set; }
    }
}

using Domain.LoginToken;

namespace Domain.AccessToken
{
    public class LoginTokenAspect : ILoginTokenAspect
    {
        public OpenIdReference OpenId { get; set; }

        public string SessionKey { get; set; }

        public string AccessTokenCode { get; set; }
    }
}

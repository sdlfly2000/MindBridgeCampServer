namespace Domain.LoginToken
{
    public class LoginToken : ILoginToken
    {
        private readonly ILoginTokenAspect _accessTokenAspect;

        public LoginToken(ILoginTokenAspect accessTokenAspect)
        {
            _accessTokenAspect = accessTokenAspect;
        }

        public OpenIdReference OpenId
        {
            get { return _accessTokenAspect.OpenId; }
            set { _accessTokenAspect.OpenId = value; }
        }
        public string AccessTokenCode
        {
            get { return _accessTokenAspect.AccessTokenCode; }
            set { _accessTokenAspect.AccessTokenCode = value; }
        }
        public string SessionKey
        {
            get { return _accessTokenAspect.SessionKey; }
            set { _accessTokenAspect.SessionKey = value; }

        }
    }
}

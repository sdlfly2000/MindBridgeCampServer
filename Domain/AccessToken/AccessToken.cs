namespace Domain.AccessToken
{
    public class AccessToken : IAccessToken
    {
        private readonly IAccessTokenAspect _accessTokenAspect;

        public AccessToken(IAccessTokenAspect accessTokenAspect)
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

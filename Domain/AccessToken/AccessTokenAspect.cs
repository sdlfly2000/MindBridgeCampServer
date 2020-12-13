namespace Domain.AccessToken
{
    public class AccessTokenAspect : IAccessTokenAspect
    {
        public OpenIdReference OpenId { get; set; }

        public string SessionKey { get; set; }

        public string AccessTokenCode { get; set; }
    }
}

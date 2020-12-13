namespace Domain.AccessToken
{
    public interface IAccessTokenAspect
    {
        OpenIdReference OpenId { get; set; }

        string AccessTokenCode { get; set; }

        string SessionKey { get; set; }
    }
}

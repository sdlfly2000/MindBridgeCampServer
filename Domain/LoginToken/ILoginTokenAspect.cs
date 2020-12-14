namespace Domain.LoginToken
{
    public interface ILoginTokenAspect
    {
        OpenIdReference OpenId { get; set; }

        string AccessTokenCode { get; set; }

        string SessionKey { get; set; }
    }
}

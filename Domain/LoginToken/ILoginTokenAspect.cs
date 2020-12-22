using Domain.User;

namespace Domain.LoginToken
{
    public interface ILoginTokenAspect
    {
        UserReference OpenId { get; set; }

        string AccessTokenCode { get; set; }

        string SessionKey { get; set; }
    }
}

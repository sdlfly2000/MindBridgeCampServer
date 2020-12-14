using Domain.LoginToken;

namespace Domain.Services.LoginToken.Loaders
{
    public interface ILoginTokenAspectLoader
    {
        ILoginTokenAspect Load(string accessToken);
    }
}

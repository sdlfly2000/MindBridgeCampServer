using Domain.User;

namespace Domain.Services.User.Gateways.Loaders
{
    public interface IUserInfoAspectLoader
    {
        IUserInfoAspect Load(UserReference reference);
    }
}

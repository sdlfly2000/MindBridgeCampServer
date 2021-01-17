using Domain.User;

namespace Domain.Services.User.Gateways.Loaders
{
    public interface IUserAspectLoader
    {
        IUserAspect Load(UserReference reference);
    }
}

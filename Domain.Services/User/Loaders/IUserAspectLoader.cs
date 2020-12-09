using Domain.User;

namespace Domain.Services.User.Loaders
{
    public interface IUserAspectLoader
    {
        IUserAspect Load(string userId);
    }
}

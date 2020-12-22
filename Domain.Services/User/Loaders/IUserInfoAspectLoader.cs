using Domain.User;

namespace Domain.Services.User.Loaders
{
    public interface IUserInfoAspectLoader
    {
        IUserInfoAspect Load(UserReference reference);
    }
}

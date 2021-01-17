using Domain.User;

namespace Domain.Services.User.Synchronizers.Persistors
{
    public interface IUserPersistor
    {
        void Add(IUserAspect aspect);

        void Update(IUserAspect aspect);
    }
}

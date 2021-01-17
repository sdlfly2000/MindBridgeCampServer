using Domain.User;

namespace Domain.Services.User.Synchronizers.Persistors
{
    public interface IUserInfoPersistor
    {
        void Add(IUserInfoAspect aspect);

        void Update(IUserInfoAspect aspect);
    }
}

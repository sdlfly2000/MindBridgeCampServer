using Domain.LearningRoom;

namespace Domain.Services.LearningRoom.Gateways.Loaders
{
    public interface ISignInAspectLoader
    {
        ISignInAspect Load(RoomReference reference);

        ISignInAspect Load(SignInReference reference);
    }
}

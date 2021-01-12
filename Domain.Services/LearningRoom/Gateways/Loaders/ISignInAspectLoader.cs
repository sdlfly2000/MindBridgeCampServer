using Domain.LearningRoom;
using System.Collections.Generic;
using Domain.User;

namespace Domain.Services.LearningRoom.Gateways.Loaders
{
    public interface ISignInAspectLoader
    {
        IList<ISignInAspect> Load(UserReference reference);

        IList<ISignInAspect> Load(RoomReference reference);

        ISignInAspect Load(SignInReference reference);
    }
}

using Domain.LearningRoom;
using System.Collections.Generic;

namespace Domain.Services.LearningRoom.Gateways.Loaders
{
    public interface ISignInAspectLoader
    {
        IList<ISignInAspect> Load(RoomReference reference);

        ISignInAspect Load(SignInReference reference);
    }
}

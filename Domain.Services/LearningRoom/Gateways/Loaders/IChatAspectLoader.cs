using Domain.LearningRoom;
using System.Collections.Generic;

namespace Domain.Services.LearningRoom.Gateways.Loaders
{
    public interface IChatAspectLoader
    {
        IList<IChatAspect> Load(RoomReference reference);

        IChatAspect Load(ChatReference reference);
    }
}

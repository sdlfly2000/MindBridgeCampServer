using Domain.LearningRoom;

namespace Domain.Services.LearningRoom.Gateways.Loaders
{
    public interface IRoomAspectLoader
    {
        IRoomAspect Load(RoomReference reference);
    }
}

using Domain.LearningRoom;

namespace Domain.Services.LearningRoom.Gateways.Loaders
{
    public interface IChatAspectLoader
    {
        IChatAspect Load(RoomReference reference);

        IChatAspect Load(ChatReference reference);
    }
}

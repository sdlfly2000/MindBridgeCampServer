using Domain.LearningRoom;

namespace Domain.Services.LearningRoom.Gateways
{
    public interface ILearningRoomWithChatsGateway
    {
        ILearningRoomWithChats Load(RoomReference reference);
    }
}

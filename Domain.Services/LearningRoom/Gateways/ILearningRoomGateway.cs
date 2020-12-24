using Domain.LearningRoom;

namespace Domain.Services.LearningRoom.Gateways
{
    public interface ILearningRoomGateway
    {
        ILearningRoom Load(RoomReference reference);
    }
}

using Domain.LearningRoom;

namespace Domain.Services.LearningRoom.Gateways
{
    public interface ILearningRoomWithSignInGateway
    {
        ILearningRoomWithSignIn Load(RoomReference reference);
    }
}

using Domain.LearningRoom;
using System.Collections.Generic;
using Domain.User;

namespace Domain.Services.LearningRoom.Gateways
{
    public interface ILearningRoomWithSignInGateway
    {
        ILearningRoomWithSignIn Load(RoomReference reference);

        IList<ILearningRoomWithSignIn> LoadByParticipant(UserReference reference);
    }
}

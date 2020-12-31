using Domain.LearningRoom;

namespace Domain.Services.LearningRoom.Gateways
{
    using System.Collections.Generic;

    public interface ILearningRoomGateway
    {
        ILearningRoom Load(RoomReference reference);

        IList<RoomReference> LoadAll();
    }
}

using System.Collections.Generic;
using Application.LearningRoom;

namespace Application.Services.LearningRoom.Processes
{
    public interface IGetRoomsParticipatedProcess
    {
        IList<LearningRoomWithStatusModel> Get(string loginToken);
    }
}

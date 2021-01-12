using System.Collections.Generic;
using Application.LearningRoom;

namespace Application.Services.LearningRoom.Processes
{
    public interface IGetRoomsParticipatedProcess
    {
        IList<LearningRoomModel> Get(string loginToken);
    }
}

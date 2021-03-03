using Application.LearningRoom;
using System.Collections.Generic;

namespace Application.Services.LearningRoom.Processes
{
    public interface IGetMessagesByRoomProcess
    {
        IList<LearningRoomMessageModel> Get(string loginToken, string roomId);
    }
}

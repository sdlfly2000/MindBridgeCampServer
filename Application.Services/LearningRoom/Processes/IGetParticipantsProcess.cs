using Application.LearningRoom;
using System.Collections.Generic;

namespace Application.Services.LearningRoom.Processes
{
    public interface IGetParticipantsProcess
    {
        IList<ParticipantModel> Get(string roomId);
    }
}

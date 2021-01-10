using Application.Services.LearningRoom.Contracts;

namespace Application.Services.LearningRoom.Processes
{
    public interface IGetRoomsParticipatedProcess
    {
        GetResponse Get(string loginToken);
    }
}

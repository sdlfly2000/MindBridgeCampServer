using Application.Services.LearningRoom.Contracts;

namespace Application.Services.LearningRoom.Processes
{
    public interface IJoinRoomProcess
    {
        GetResponse Join(string loginToken, string roomId);

        bool IsJoin(string loginToken, string roomId);
    }
}

using Application.Services.LearningRoom.Contracts;
using Application.LearningRoom;

namespace Application.Services.LearningRoom
{
    public interface ILearningRoomService
    {
        GetResponse GetAvailableRooms();

        void CreateRoom(string loginToken, LearningRoomModel model);
    }
}

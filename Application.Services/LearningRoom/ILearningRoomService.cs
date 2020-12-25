using Application.Services.LearningRoom.Contracts;

namespace Application.Services.LearningRoom
{
    public interface ILearningRoomService
    {
        GetResponse GetAvailableRooms();
    }
}

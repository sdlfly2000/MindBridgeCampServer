using Application.Services.LearningRoom.Contracts;
using Application.LearningRoom;
using System.Collections.Generic;

namespace Application.Services.LearningRoom
{
    public interface ILearningRoomService
    {
        GetResponse GetAvailableRooms();

        IList<LearningRoomModel> GetRoomsParticipated(string loginToken);

        void CreateRoom(string loginToken, LearningRoomModel model);

        GetResponse JoinRoom(string loginToken, string roomId);

        void SignInRoom(string loginToken, string roomId);

        IList<ParticipantModel> GetParticipants(string roomId);
    }
}

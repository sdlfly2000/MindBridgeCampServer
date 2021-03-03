using Application.Services.LearningRoom.Contracts;
using Application.LearningRoom;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services.LearningRoom
{
    public interface ILearningRoomService
    {
        GetResponse GetAvailableRooms();

        IList<LearningRoomModel> GetRoomsParticipated(string loginToken);

        void CreateRoom(string loginToken, LearningRoomModel model);

        GetResponse JoinRoom(string loginToken, string roomId);

        bool IsJoinRoom(string loginToken, string roomId);

        void SignInRoom(string loginToken, string roomId);

        IList<ParticipantModel> GetParticipants(string roomId);

        Task CreateChatMessage(string loginToken, string roomId, string message);

        IList<LearningRoomMessageModel> GetMessagesByRoom(string loginToken, string roomId);
    }
}

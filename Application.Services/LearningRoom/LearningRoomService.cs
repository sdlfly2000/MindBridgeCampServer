using Application.Services.LearningRoom.Contracts;
using Application.Services.LearningRoom.Processes;
using Common.Core.DependencyInjection;
using Application.LearningRoom;
using System.Collections.Generic;

namespace Application.Services.LearningRoom
{
    [ServiceLocate(typeof(ILearningRoomService))]
    public class LearningRoomService : ILearningRoomService
    {
        private readonly IGetAvailableRoomProcess _getAvailableRoomProcess;
        private readonly ICreateRoomProcess _createRoomProcess;
        private readonly IJoinRoomProcess _joinRoomProcess;
        private readonly IGetParticipantsProcess _getParticipantsProcess;

        public LearningRoomService(
            IGetAvailableRoomProcess getAvailableRoomProcess,
            ICreateRoomProcess createRoomProcess,
            IJoinRoomProcess joinRoomProcess,
            IGetParticipantsProcess getParticipantsProcess)
        {
            _getAvailableRoomProcess = getAvailableRoomProcess;
            _createRoomProcess = createRoomProcess;
            _joinRoomProcess = joinRoomProcess;
            _getParticipantsProcess = getParticipantsProcess;
        }

        public GetResponse GetAvailableRooms()
        {
            return _getAvailableRoomProcess.Get();
        }

        public void CreateRoom(string loginToken, LearningRoomModel model)
        {
            _createRoomProcess.Create(loginToken, model);
        }

        public GetResponse JoinRoom(string loginToken, string roomId)
        {
            return _joinRoomProcess.Join(loginToken, roomId);
        }

        public IList<ParticipantModel> GetParticipants(string roomId)
        {
            return _getParticipantsProcess.Get(roomId);
        }
    }
}

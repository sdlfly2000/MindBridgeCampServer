using Application.Services.LearningRoom.Contracts;
using Application.Services.LearningRoom.Processes;
using Common.Core.DependencyInjection;
using Application.LearningRoom;

namespace Application.Services.LearningRoom
{
    [ServiceLocate(typeof(ILearningRoomService))]
    public class LearningRoomService : ILearningRoomService
    {
        private readonly IGetAvailableRoomProcess _getAvailableRoomProcess;
        private readonly ICreateRoomProcess _createRoomProcess;
        private readonly IJoinRoomProcess _joinRoomProcess;

        public LearningRoomService(
            IGetAvailableRoomProcess getAvailableRoomProcess,
            ICreateRoomProcess createRoomProcess,
            IJoinRoomProcess joinRoomProcess)
        {
            _getAvailableRoomProcess = getAvailableRoomProcess;
            _createRoomProcess = createRoomProcess;
            _joinRoomProcess = joinRoomProcess;
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
    }
}

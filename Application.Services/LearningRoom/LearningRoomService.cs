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

        public LearningRoomService(
            IGetAvailableRoomProcess getAvailableRoomProcess,
            ICreateRoomProcess createRoomProcess)
        {
            _getAvailableRoomProcess = getAvailableRoomProcess;
            _createRoomProcess = createRoomProcess;
        }

        public GetResponse GetAvailableRooms()
        {
            return _getAvailableRoomProcess.Get();
        }

        public void CreateRoom(LearningRoomModel model)
        {
            _createRoomProcess.Create(model);
        }
    }
}

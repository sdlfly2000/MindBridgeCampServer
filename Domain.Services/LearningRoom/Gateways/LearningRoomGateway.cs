using Common.Core.DependencyInjection;
using Domain.Services.LearningRoom.Gateways.Loaders;
using Domain.LearningRoom;

namespace Domain.Services.LearningRoom.Gateways
{
    [ServiceLocate(typeof(ILearningRoomGateway))]
    public class LearningRoomGateway : ILearningRoomGateway
    {
        private readonly IRoomAspectLoader _roomAspectLoader;

        public LearningRoomGateway(IRoomAspectLoader roomAspectLoader)
        {
            _roomAspectLoader = roomAspectLoader;
        }

        public ILearningRoom Load(RoomReference reference)
        {
            var roomAspect = _roomAspectLoader.Load(reference);
            return new LearningRoomDomain(roomAspect);
        }
    }
}

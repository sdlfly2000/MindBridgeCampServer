using Common.Core.DependencyInjection;
using Domain.Services.LearningRoom.Gateways.Loaders;
using Domain.LearningRoom;
using System.Collections.Generic;
using Infrastructure.Data.Sql.LearningRoom.Repositories;
using System.Linq;

namespace Domain.Services.LearningRoom.Gateways
{
    [ServiceLocate(typeof(ILearningRoomGateway))]
    public class LearningRoomGateway : ILearningRoomGateway
    {
        private readonly IRoomAspectLoader _roomAspectLoader;
        private readonly IRoomRepository _roomRepository;

        public LearningRoomGateway(
            IRoomAspectLoader roomAspectLoader,
            IRoomRepository roomRepository)
        {
            _roomAspectLoader = roomAspectLoader;
            _roomRepository = roomRepository;
        }

        public ILearningRoom Load(RoomReference reference)
        {
            var roomAspect = _roomAspectLoader.Load(reference);
            return new LearningRoomDomain(roomAspect);
        }

        public IList<RoomReference> LoadAll()
        {
            var allRooms = _roomRepository.FindAllRooms();
            return allRooms
                .Select(roomEntity => new RoomReference(roomEntity.roomId))
                .ToList();
        }
    }
}

using Common.Core.DependencyInjection;
using Domain.LearningRoom;
using Domain.Services.LearningRoom.Gateways.Loaders.Mappers;
using Infrastructure.Data.Sql.LearningRoom.Repositories;

namespace Domain.Services.LearningRoom.Gateways.Loaders
{
    [ServiceLocate(typeof(IRoomAspectLoader))]
    public class RoomAspectLoader : IRoomAspectLoader
    {
        private readonly IRoomAspectMapper _roomAspectMapper;
        private readonly IRoomRepository _roomRepository;
        private readonly IParticipantRepository _participantRepository;

        public RoomAspectLoader(
            IRoomAspectMapper roomAspectMapper,
            IRoomRepository roomRepository,
            IParticipantRepository participantRepository)
        {
            _roomAspectMapper = roomAspectMapper;
            _roomRepository = roomRepository;
            _participantRepository = participantRepository;
        }

        public IRoomAspect Load(RoomReference reference)
        {
            var roomEntity = _roomRepository.FindById(reference.Code);
            var participants = _participantRepository.FindByRoom(reference.Code);

            return _roomAspectMapper.Map(roomEntity, participants);
        }
    }
}

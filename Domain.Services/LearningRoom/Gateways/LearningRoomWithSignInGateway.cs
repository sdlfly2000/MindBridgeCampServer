using Common.Core.DependencyInjection;
using Domain.LearningRoom;
using Domain.Services.LearningRoom.Gateways.Loaders;
using System.Collections.Generic;
using System.Linq;
using Domain.User;
using Infrastructure.Data.Sql.LearningRoom.Repositories;

namespace Domain.Services.LearningRoom.Gateways
{
    [ServiceLocate(typeof(ILearningRoomWithSignInGateway))]
    public class LearningRoomWithSignInGateway : ILearningRoomWithSignInGateway
    {
        private readonly IRoomAspectLoader _roomAspectLoader;
        private readonly ISignInAspectLoader _signInAspectLoader;
        private readonly IRoomRepository _roomRepository;

        public LearningRoomWithSignInGateway(
            IRoomAspectLoader roomAspectLoader,
            ISignInAspectLoader signInAspectLoader,
            IRoomRepository roomRepository)
        {
            _roomAspectLoader = roomAspectLoader;
            _signInAspectLoader = signInAspectLoader;
            _roomRepository = roomRepository;
        }

        public ILearningRoomWithSignIn Load(RoomReference reference)
        {
            var roomAspect = _roomAspectLoader.Load(reference);
            var signInAspects = _signInAspectLoader.Load(reference);
            return new LearningRoomWithSignIn(roomAspect)
            {
                SignIns = signInAspects
            };
        }

        public IList<ILearningRoomWithSignIn> LoadByParticipant(UserReference reference)
        {
            var roomReferences = _roomRepository.FindAllRooms().Select(e => new RoomReference(e.roomId)).ToList();
            var roomsParticipated = roomReferences
                .Select(_roomAspectLoader.Load)
                .Where(aspect => aspect.Participants.Any(p => p.User.Equals(reference)))
                .ToList();

            return roomsParticipated
                .Select(room =>
                    {
                        var roomWithSignIn = new LearningRoomWithSignIn(room);
                        roomWithSignIn.SignIns = _signInAspectLoader.Load(room.Reference);
                        return roomWithSignIn;
                    })
                .OfType<ILearningRoomWithSignIn>()
                .ToList();
        }
    }
}

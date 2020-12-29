using Common.Core.DependencyInjection;
using Domain.LearningRoom;
using Domain.Services.LearningRoom.Gateways.Loaders;

namespace Domain.Services.LearningRoom.Gateways
{
    [ServiceLocate(typeof(ILearningRoomWithSignInGateway))]
    public class LearningRoomWithSignInGateway : ILearningRoomWithSignInGateway
    {
        private readonly IRoomAspectLoader _roomAspectLoader;
        private readonly ISignInAspectLoader _signInAspectLoader;

        public LearningRoomWithSignInGateway(
            IRoomAspectLoader roomAspectLoader,
            ISignInAspectLoader signInAspectLoader)
        {
            _roomAspectLoader = roomAspectLoader;
            _signInAspectLoader = signInAspectLoader;
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
    }
}

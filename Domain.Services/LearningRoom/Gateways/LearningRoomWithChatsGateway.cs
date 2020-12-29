using Common.Core.DependencyInjection;
using Domain.LearningRoom;
using Domain.Services.LearningRoom.Gateways.Loaders;

namespace Domain.Services.LearningRoom.Gateways
{
    [ServiceLocate(typeof(ILearningRoomWithChatsGateway))]
    public class LearningRoomWithChatsGateway : ILearningRoomWithChatsGateway
    {
        private readonly IRoomAspectLoader _roomAspectLoader;
        private readonly IChatAspectLoader _chatAspectLoader;

        public LearningRoomWithChatsGateway(
            IRoomAspectLoader roomAspectLoader,
            IChatAspectLoader chatAspectLoader)
        {
            _roomAspectLoader = roomAspectLoader;
            _chatAspectLoader = chatAspectLoader;
        }

        public ILearningRoomWithChats Load(RoomReference reference)
        {
            var roomAspect = _roomAspectLoader.Load(reference);
            var chatsAspects = _chatAspectLoader.Load(reference);
            return new LearningRoomWithChats(roomAspect) 
            {
                ChatAspects = chatsAspects
            };
        }
    }
}

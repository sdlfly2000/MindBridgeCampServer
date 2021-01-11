using System.Linq;
using Common.Core.DependencyInjection;
using Domain.LearningRoom;
using Domain.Services.LearningRoom.Gateways;
using Domain.Services.LearningRoom.Synchronizors.Persistors;
using Infrastructure.Data.Sql.Persistence;

namespace Domain.Services.LearningRoom.Synchronizors
{
    [ServiceLocate(typeof(ILearningRoomWithChatsSynchronizor))]
    public class LearningRoomWithChatsSynchronizor : ILearningRoomWithChatsSynchronizor
    {
        private readonly ILearningRoomWithChatsGateway _learningRoomWithChatsGateway;
        private readonly IChatPersistor _chatPersistor;
        private readonly IPersistence _persistence;

        public LearningRoomWithChatsSynchronizor(
            ILearningRoomWithChatsGateway learningRoomWithChatsGateway,
            IChatPersistor chatPersistor,
            IPersistence persistence)
        {
            _learningRoomWithChatsGateway = learningRoomWithChatsGateway;
            _chatPersistor = chatPersistor;
            _persistence = persistence;
        }

        public void Update(ILearningRoomWithChats learningRoom)
        {
            var learningRoomWithChat = _learningRoomWithChatsGateway.Load(learningRoom.Reference);
            var chatsAdded = learningRoom.ChatAspects
                .Where(chat => learningRoomWithChat.ChatAspects.Any(c => c.Reference.Equals(chat.Reference)))
                .ToList();

            chatsAdded.ForEach(c => _chatPersistor.Add(c));
            _persistence.Complete();
        }
    }
}

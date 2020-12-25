using Common.Core.DependencyInjection;
using Domain.LearningRoom;
using Domain.User;
using Infrastructure.Data.Sql.LearningRoom.Entities;

namespace Domain.Services.LearningRoom.Gateways.Loaders.Mappers
{
    [ServiceLocate(typeof(IChatAspectMapper))]
    public class ChatAspectMapper : IChatAspectMapper
    {
        public IChatAspect Map(ChatEntity entity)
        {
            return new ChatAspect
            {
                Content = entity.content,
                CreatedBy = new UserReference(entity.createdBy),
                CreatedOn = entity.createdOn,
                Reference = new ChatReference(entity.chatId),
                Room = new RoomReference(entity.roomId)
            };
        }
    }
}

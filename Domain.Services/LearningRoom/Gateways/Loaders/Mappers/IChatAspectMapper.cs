using Domain.LearningRoom;
using Infrastructure.Data.Sql.LearningRoom.Entities;

namespace Domain.Services.LearningRoom.Gateways.Loaders.Mappers
{
    public interface IChatAspectMapper
    {
        IChatAspect Map(ChatEntity entity);
    }
}

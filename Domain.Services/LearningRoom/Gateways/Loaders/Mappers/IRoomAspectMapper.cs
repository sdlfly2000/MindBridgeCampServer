using Domain.LearningRoom;
using Infrastructure.Data.Sql.LearningRoom.Entities;
using System.Collections.Generic;

namespace Domain.Services.LearningRoom.Gateways.Loaders.Mappers
{
    public interface IRoomAspectMapper
    {
        IRoomAspect Map(RoomEntity entity, IList<ParticipantEntity> participants);
    }
}

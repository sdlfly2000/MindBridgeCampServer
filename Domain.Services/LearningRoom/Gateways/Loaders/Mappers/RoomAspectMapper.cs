using Common.Core.DependencyInjection;
using Domain.LearningRoom;
using Domain.User;
using Infrastructure.Data.Sql.LearningRoom.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Services.LearningRoom.Gateways.Loaders.Mappers
{
    [ServiceLocate(typeof(IRoomAspectMapper))]
    public class RoomAspectMapper : IRoomAspectMapper
    {
        public IRoomAspect Map(RoomEntity entity, IList<ParticipantEntity> participants)
        {
            return new RoomAspect
            {
                Reference = new RoomReference(entity.roomId),
                Title = entity.title,
                LearningContent = entity.learningContent,
                StartDate = entity.startDate,
                EndDate = entity.endDate,
                ParticipantCount = entity.participantCount,
                Place = entity.place,
                CreatedBy = new UserReference(entity.CreatedBy),
                CreatedOn = entity.CreatedOn,
                Participants = participants
                    .Select(entity => new Participant 
                    { 
                        Reference = new ParticipantReference(entity.participantId),
                        Room = new RoomReference(entity.roomId),
                        User = new UserReference(entity.userId),
                        IsDeleted = entity.isDeleted
                    }).ToList()
            };
        }
    }
}

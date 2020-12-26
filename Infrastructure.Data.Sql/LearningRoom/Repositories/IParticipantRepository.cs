using Infrastructure.Data.Sql.LearningRoom.Entities;
using System.Collections.Generic;

namespace Infrastructure.Data.Sql.LearningRoom.Repositories
{
    public interface IParticipantRepository
    {
        ParticipantEntity FindById(string id);

        IList<ParticipantEntity> FindByRoom(string roomId);
    }
}

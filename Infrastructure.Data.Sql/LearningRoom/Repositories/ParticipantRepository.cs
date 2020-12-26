using Common.Core.DependencyInjection;
using Infrastructure.Data.Sql.LearningRoom.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Data.Sql.LearningRoom.Repositories
{
    [ServiceLocate(typeof(IParticipantRepository))]
    public class ParticipantRepository : IParticipantRepository
    {
        private readonly IMindBridgeCampDbContext _context;

        public ParticipantRepository(IMindBridgeCampDbContext context)
        {
            _context = context;
        }

        public ParticipantEntity FindById(string id)
        {
            return FindAll().FirstOrDefault(p => p.participantId.Equals(id));
        }

        public IList<ParticipantEntity> FindByRoom(string roomId)
        {
            return FindAll().Where(p => p.roomId.Equals(roomId)).ToList();
        }

        private IQueryable<ParticipantEntity> FindAll()
        {
            return _context.Participants.AsQueryable();
        }
    }
}

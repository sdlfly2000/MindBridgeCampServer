using Common.Core.DependencyInjection;
using Infrastructure.Data.Sql.LearningRoom.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Data.Sql.LearningRoom.Repositories
{
    [ServiceLocate(typeof(IRoomRepository))]
    public class RoomRepository : IRoomRepository
    {
        private readonly IMindBridgeCampDbContext _context;

        public RoomRepository(IMindBridgeCampDbContext context)
        {
            _context = context;
        }

        public IList<RoomEntity> FindAllRooms()
        {
            return FindAll().ToList();
        }

        public RoomEntity FindById(string id)
        {
            return FindAll().FirstOrDefault(room => room.roomId.Equals(id));
        }

        private IQueryable<RoomEntity> FindAll()
        {
            return _context.Rooms.AsQueryable();
        }
    }
}

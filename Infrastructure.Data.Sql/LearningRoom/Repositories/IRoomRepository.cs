using Infrastructure.Data.Sql.LearningRoom.Entities;
using System.Collections.Generic;

namespace Infrastructure.Data.Sql.LearningRoom.Repositories
{
    public interface IRoomRepository
    {
        RoomEntity FindById(string id);

        IList<RoomEntity> FindAllRooms();
    }
}

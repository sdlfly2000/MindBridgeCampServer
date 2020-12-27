using Infrastructure.Data.Sql.LearningRoom.Entities;
using System.Collections.Generic;

namespace Infrastructure.Data.Sql.LearningRoom.Repositories
{
    public interface IChatRepository
    {
        ChatEntity FindById(string id);

        IList<ChatEntity> FindByRoom(string roomId);
    }
}

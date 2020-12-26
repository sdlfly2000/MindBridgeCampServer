using Common.Core.DependencyInjection;
using Infrastructure.Data.Sql.LearningRoom.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Data.Sql.LearningRoom.Repositories
{
    [ServiceLocate(typeof(IChatRepository))]
    public class ChatRepository : IChatRepository
    {
        private readonly IMindBridgeCampDbContext _context;

        public ChatRepository(IMindBridgeCampDbContext context)
        {
            _context = context;
        }

        public ChatEntity FindById(string id)
        {
            return FindAll().FirstOrDefault(chat => chat.chatId.Equals(id));
        }

        public IList<ChatEntity> FindByRoom(string roomId)
        {
            return FindAll().Where(chat => chat.roomId.Equals(roomId)).ToList();
        }

        private IQueryable<ChatEntity> FindAll()
        {
            return _context.Chats.AsQueryable();
        }
    }
}

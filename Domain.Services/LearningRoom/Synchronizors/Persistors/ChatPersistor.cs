using Common.Core.DependencyInjection;
using Domain.LearningRoom;
using Infrastructure.Data.Sql.LearningRoom.Entities;
using Infrastructure.Data.Sql.Persistence.UnitOfWork;
using Infrastructure.Data.Sql.Persistence;

namespace Domain.Services.LearningRoom.Synchronizors.Persistors
{
    [ServiceLocate(typeof(IChatPersistor))]
    public class ChatPersistor : Persistor<IChatAspect, ChatEntity>, IChatPersistor
    {
        public ChatPersistor(IUnitOfWork<ChatEntity> uow) 
            : base(uow)
        {
        }

        protected override ChatEntity Map(IChatAspect aspect)
        {
            return new ChatEntity
            {
               chatId = aspect.Reference.Code,
               roomId = aspect.Room.Code,
               createdBy = aspect.CreatedBy.Code,
               createdOn = aspect.CreatedOn,
               content = aspect.Content
            };
        }
    }
}

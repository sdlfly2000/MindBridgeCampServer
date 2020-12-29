using Common.Core.DependencyInjection;
using Domain.LearningRoom;
using Infrastructure.Data.Sql.LearningRoom.Entities;
using Infrastructure.Data.Sql.Persistence.UnitOfWork;

namespace Domain.Services.LearningRoom.Synchronizors.Persistors
{
    [ServiceLocate(typeof(IChatPersistor))]
    public class ChatPersistor : IChatPersistor
    {
        private readonly IUnitOfWork<ChatEntity> _uow;

        public ChatPersistor(IUnitOfWork<ChatEntity> uow)
        {
            _uow = uow;
        }

        public void Add(IChatAspect aspect)
        {
            _uow.Add(Map(aspect));
        }

        public void Update(IChatAspect aspect)
        {
            _uow.Persist(Map(aspect));
        }

        #region Private Methods

        private ChatEntity Map(IChatAspect aspect)
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

        #endregion
    }
}

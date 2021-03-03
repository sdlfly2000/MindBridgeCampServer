using Common.Core.DependencyInjection;
using Domain.LearningRoom;
using Domain.Services.LearningRoom.Gateways.Loaders.Mappers;
using Infrastructure.Data.Sql.LearningRoom.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Services.LearningRoom.Gateways.Loaders
{
    [ServiceLocate(typeof(IChatAspectLoader))]
    public class ChatAspectLoader : IChatAspectLoader
    {
        private readonly IChatRepository _chatRepository;
        private readonly IChatAspectMapper _chatAspectMapper;

        public ChatAspectLoader(
            IChatRepository chatRepository,
            IChatAspectMapper chatAspectMapper)
        {
            _chatRepository = chatRepository;
            _chatAspectMapper = chatAspectMapper;
        }

        public IChatAspect Load(ChatReference reference)
        {
            return _chatAspectMapper.Map(_chatRepository.FindById(reference.Code));
        }

        public IList<IChatAspect> Load(RoomReference reference)
        {
            return _chatRepository
                .FindByRoom(reference.Code)
                .Select(_chatAspectMapper.Map)
                .ToList();
        }
    }
}

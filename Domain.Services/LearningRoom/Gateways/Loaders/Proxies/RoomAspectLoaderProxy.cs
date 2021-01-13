using System.Reflection;
using Common.Core.AOP;
using Common.Core.DependencyInjection;
using Domain.LearningRoom;
using Domain.Services.LearningRoom.Gateways.Loaders.Mappers;
using Infrastructure.Data.Sql.LearningRoom.Repositories;
using Microsoft.Extensions.Caching.Memory;

namespace Domain.Services.LearningRoom.Gateways.Loaders.Proxies
{
    [ServiceLocate(typeof(IRoomAspectLoader))]
    public class RoomAspectLoaderProxy :  IRoomAspectLoader
    {
        private RoomAspectLoader _roomAspectLoader;
        private IRoomAspectLoader _roomApsectLoaderDecorator;

        public RoomAspectLoaderProxy(
            IRoomAspectMapper roomAspectMapper,
            IRoomRepository roomRepository,
            IParticipantRepository participantRepository,
            IMemoryCache memoryCache)
        {
            _roomAspectLoader = new RoomAspectLoader(roomAspectMapper, roomRepository, participantRepository);
            _roomApsectLoaderDecorator = DispatchProxy.Create<IRoomAspectLoader, CacheProxy>();
            ((CacheProxy)_roomApsectLoaderDecorator).Wrapped = _roomAspectLoader;
            ((CacheProxy)_roomApsectLoaderDecorator).CacheAction = new CacheAction<IRoomAspect, RoomReference>(memoryCache);
        }

        public IRoomAspect Load(RoomReference reference)
        {
            return _roomApsectLoaderDecorator.Load(reference);
        }
    }
}

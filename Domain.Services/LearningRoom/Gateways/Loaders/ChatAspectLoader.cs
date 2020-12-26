using Common.Core.DependencyInjection;
using Domain.LearningRoom;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Services.LearningRoom.Gateways.Loaders
{
    [ServiceLocate(typeof(IChatAspectLoader))]
    public class ChatAspectLoader : IChatAspectLoader
    {
        public ChatAspectLoader()
        {

        }

        public IChatAspect Load(RoomReference reference)
        {
            throw new NotImplementedException();
        }

        public IChatAspect Load(ChatReference reference)
        {
            throw new NotImplementedException();
        }
    }
}

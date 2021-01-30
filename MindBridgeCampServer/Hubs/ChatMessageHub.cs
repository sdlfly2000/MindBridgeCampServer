using Common.Core.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MindBridgeCampServer.Hubs
{
    [ServiceLocate(typeof(IChatMessageHub))]
    public class ChatMessageHub : IChatMessageHub
    {
        public ChatMessageHub()
        {

        }
    }
}

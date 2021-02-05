using Common.Core.DependencyInjection;
using Core;
using Domain.LearningRoom;
using Domain.Services.LearningRoom.Gateways;
using Domain.Services.LearningRoom.Synchronizors;
using Domain.Services.LoginToken;
using System;
using System.Threading.Tasks;

namespace Application.Services.LearningRoom.Processes
{
    [ServiceLocate(typeof(ICreateChatMessageProcess))]
    public class CreateChatMessageProcess : ICreateChatMessageProcess
    {
        private readonly ILoginTokenGateway _loginTokenGateway;
        private readonly ILearningRoomWithChatsGateway _learningRoomGateway;
        private readonly ILearningRoomWithChatsSynchronizor _learningRoomWithChatsSynchronizor;

        public CreateChatMessageProcess(
            ILoginTokenGateway loginTokenGateway,
            ILearningRoomWithChatsGateway learningRoomGateway,
            ILearningRoomWithChatsSynchronizor learningRoomWithChatsSynchronizor)
        {
            _loginTokenGateway = loginTokenGateway;
            _learningRoomGateway = learningRoomGateway;
            _learningRoomWithChatsSynchronizor = learningRoomWithChatsSynchronizor;
        }

        public async Task CreateChatMessage(string loginToken, string roomId, string message)
        {
            var login = _loginTokenGateway.Get(loginToken);
            var roomReference = new RoomReference(roomId, CacheField.Room);
            var learningRoom = _learningRoomGateway.Load(roomReference);
            learningRoom.ChatAspects.Add(new ChatAspect
            {
                Reference = new ChatReference(Guid.NewGuid().ToString()),
                Room = roomReference,
                Content = message,
                CreatedBy = login.OpenId,
                CreatedOn = DateTimeUtil.GetNow()
            });

            await Task.Run(() => _learningRoomWithChatsSynchronizor.Update(learningRoom));
        }
    }
}

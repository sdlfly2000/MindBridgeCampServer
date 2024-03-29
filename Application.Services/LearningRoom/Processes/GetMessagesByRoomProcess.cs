﻿using Application.LearningRoom;
using Common.Core.DependencyInjection;
using Domain.LearningRoom;
using Domain.Services.LearningRoom.Gateways;
using Domain.Services.LoginToken;
using Domain.Services.User;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services.LearningRoom.Processes
{
    [ServiceLocate(typeof(IGetMessagesByRoomProcess))]
    public class GetMessagesByRoomProcess : IGetMessagesByRoomProcess
    {
        private readonly ILoginTokenGateway _loginTokenGateway;
        private readonly IUserGateway _userGateway;
        private readonly ILearningRoomWithChatsGateway _learningRoomWithChatsGateway;

        public GetMessagesByRoomProcess(
            ILoginTokenGateway loginTokenGateway,
            IUserGateway userGateway,
            ILearningRoomWithChatsGateway learningRoomWithChatsGateway)
        {
            _loginTokenGateway = loginTokenGateway;
            _userGateway = userGateway;
            _learningRoomWithChatsGateway = learningRoomWithChatsGateway;
        }

        public IList<LearningRoomMessageModel> Get(string loginToken, string roomId)
        {
            var login = _loginTokenGateway.Get(loginToken);
            var roomWithChats = _learningRoomWithChatsGateway.Load(new RoomReference(roomId));

            return roomWithChats.ChatAspects != null
                ? roomWithChats.ChatAspects.Select(aspect => new LearningRoomMessageModel
                    {
                        Content = aspect.Content,
                        CreatedByNickName = _userGateway.Load(aspect.CreatedBy.Code).NickName,
                        IsCreatedByRequester = aspect.CreatedBy.Equals(login.OpenId),
                        CreatedOn = aspect.CreatedOn
                    }).OrderBy(model => model.CreatedOn).ToList()
                : new List<LearningRoomMessageModel>();
        }
    }
}

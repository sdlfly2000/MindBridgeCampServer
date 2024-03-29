﻿using Application.LearningRoom;
using Application.Services.LearningRoom.Contracts;
using Common.Core.DependencyInjection;
using Core;
using Domain.LearningRoom;
using Domain.Services.LearningRoom.Gateways;
using Domain.Services.LearningRoom.Synchronizors;
using Domain.Services.LoginToken;
using System;
using System.Linq;

namespace Application.Services.LearningRoom.Processes
{
    [ServiceLocate(typeof(IJoinRoomProcess))]
    public class JoinRoomProcess : IJoinRoomProcess
    {
        private const string DateFormat = "yyyy-MM-dd HH:mm";

        private readonly ILearningRoomGateway _learningRoomGateway;
        private readonly ILearningRoomSynchronizor _learningRoomSynchronizor;
        private readonly ILoginTokenGateway _loginTokenGateway;

        public JoinRoomProcess(
            ILearningRoomGateway learningRoomGateway,
            ILearningRoomSynchronizor learningRoomSynchronizor,
            ILoginTokenGateway loginTokenGateway)
        {
            _learningRoomGateway = learningRoomGateway;
            _learningRoomSynchronizor = learningRoomSynchronizor;
            _loginTokenGateway = loginTokenGateway;
        }

        public bool IsJoin(string loginToken, string roomId)
        {
            var login = _loginTokenGateway.Get(loginToken);
            var room = _learningRoomGateway.Load(new RoomReference(roomId, CacheField.Room));

            return room.Participants.Any(p => p.User.Equals(login.OpenId));
        }

        public GetResponse Join(string loginToken, string roomId)
        {
            var response = new GetResponse();

            var room = _learningRoomGateway.Load(new RoomReference(roomId, CacheField.Room));
            var user = _loginTokenGateway.Get(loginToken);

            if(!room.Participants.Any(p => p.User.Equals(user.OpenId)))
            {
                var participant = new Participant
                {
                    Reference = new ParticipantReference(Guid.NewGuid().ToString()),
                    IsDeleted = false,
                    Room = new RoomReference(roomId, CacheField.Room),
                    User = user.OpenId
                };

                _learningRoomSynchronizor.AddParticipant(participant);
            }

            var roomUpdate = _learningRoomGateway.Load(new RoomReference(room.Reference.Code, CacheField.Room));

            response.LearningRooms.Add(new LearningRoomModel
            {
                RoomId = roomUpdate.Reference.Code,
                CreatedOn = roomUpdate.CreatedOn.ToString(DateFormat),
                CreatedBy = roomUpdate.CreatedBy.Code,
                EndDate = roomUpdate.EndDate.ToString(DateFormat),
                LearningContent = roomUpdate.LearningContent,
                Place = roomUpdate.Place,
                ParticipantCount = roomUpdate.ParticipantCount,
                StartDate = roomUpdate.StartDate.ToString(DateFormat),
                Title = roomUpdate.Title,
                CurrentParticipantCount = roomUpdate.CurrentParticipantCount
            });

            return response;
        }
    }
}

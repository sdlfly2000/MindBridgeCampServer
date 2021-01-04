using Application.LearningRoom;
using Application.Services.LearningRoom.Contracts;
using Common.Core.DependencyInjection;
using Domain.LearningRoom;
using Domain.Services.LearningRoom.Gateways;
using Domain.Services.LearningRoom.Synchronizors;
using Domain.Services.LoginToken;
using Domain.User;
using System;

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

        public GetResponse Join(string loginToken, string roomId)
        {
            var response = new GetResponse();

            var room = _learningRoomGateway.Load(new RoomReference(roomId));
            //var user = _loginTokenGateway.Get(loginToken);

            var participant = new Participant 
            {
                Reference = new ParticipantReference(Guid.NewGuid().ToString()),
                IsDeleted = false,
                Room = new RoomReference(roomId),
                User = new UserReference(loginToken)
            };

            room.Participants.Add(participant);

            _learningRoomSynchronizor.Update(room);

            var roomUpdate = _learningRoomGateway.Load(room.Reference);

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

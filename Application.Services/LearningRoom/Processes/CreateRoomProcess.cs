using System;
using System.Collections.Generic;
using Application.LearningRoom;
using Common.Core.DependencyInjection;
using Domain.LearningRoom;
using Domain.Services.LearningRoom.Synchronizors;
using Domain.Services.LoginToken;
using Domain.User;

namespace Application.Services.LearningRoom.Processes
{
    [ServiceLocate(typeof(ICreateRoomProcess))]
    public class CreateRoomProcess : ICreateRoomProcess
    {
        private readonly ILearningRoomSynchronizor _learningRoomSynchronizor;
        private readonly ILoginTokenGateway _loginTokenGateway;

        public CreateRoomProcess(
            ILearningRoomSynchronizor learningRoomSynchronizor,
            ILoginTokenGateway loginTokenGateway)
        {
            _learningRoomSynchronizor = learningRoomSynchronizor;
            _loginTokenGateway = loginTokenGateway;
        }

        public void Create(string loginToken, LearningRoomModel model)
        {
            var login = _loginTokenGateway.Get(loginToken);
            var roomReference = new RoomReference(Guid.NewGuid().ToString());

            var roomAspct = new RoomAspect
            {
                Reference = roomReference,
                CreatedBy = login.OpenId,
                CreatedOn = DateTime.Parse(model.CreatedOn),
                EndDate = DateTime.Parse(model.EndDate),
                LearningContent = model.LearningContent,
                Place = model.Place,
                ParticipantCount = model.ParticipantCount,
                StartDate = DateTime.Parse(model.StartDate),
                Title = model.Title,
                Participants = new List<Participant>
                {
                    new Participant
                    {
                        Reference = new ParticipantReference(Guid.NewGuid().ToString()),
                        IsDeleted = false,
                        Room = roomReference,
                        User = login.OpenId
                    }
                }
            };

            _learningRoomSynchronizor.Add(new LearningRoomDomain(roomAspct));
        }
    }
}

using System;
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

            var roomAspct = new RoomAspect
            {
                Reference = new RoomReference(Guid.NewGuid().ToString()),
                CreatedBy = login.OpenId,
                CreatedOn = model.CreatedOn,
                EndDate = model.EndDate,
                LearningContent = model.LearningContent,
                Place = model.Place,
                ParticipantCount = model.ParticipantCount,
                StartDate = model.StartDate,
                Title = model.Title
            };

            _learningRoomSynchronizor.Add(new LearningRoomDomain(roomAspct));
        }
    }
}

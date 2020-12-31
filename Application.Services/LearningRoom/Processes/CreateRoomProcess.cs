using System;
using Application.LearningRoom;
using Common.Core.DependencyInjection;
using Domain.LearningRoom;
using Domain.Services.LearningRoom.Synchronizors;
using Domain.User;

namespace Application.Services.LearningRoom.Processes
{
    [ServiceLocate(typeof(ICreateRoomProcess))]
    public class CreateRoomProcess : ICreateRoomProcess
    {
        private readonly ILearningRoomSynchronizor _learningRoomSynchronizor;

        public CreateRoomProcess(
            ILearningRoomSynchronizor learningRoomSynchronizor)
        {
            _learningRoomSynchronizor = learningRoomSynchronizor;
        }

        public void Create(LearningRoomModel model)
        {
            var roomAspct = new RoomAspect
            {
                Reference = new RoomReference(Guid.NewGuid().ToString()),
                CreatedBy = new UserReference(model.CreatedBy),
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

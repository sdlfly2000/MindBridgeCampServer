using System;
using System.Linq;
using Application.Services.LearningRoom.Contracts;
using Common.Core.DependencyInjection;
using Domain.Services.LearningRoom.Gateways;
using Application.LearningRoom;

namespace Application.Services.LearningRoom.Processes
{
    [ServiceLocate(typeof(IGetAvailableRoomProcess))]
    public class GetAvailableRoomProcess :IGetAvailableRoomProcess
    {
        private readonly ILearningRoomGateway _learningRoomGateway;

        public GetAvailableRoomProcess(
            ILearningRoomGateway learningRoomGateway)
        {
            _learningRoomGateway = learningRoomGateway;
        }

        public GetResponse Get()
        {
            var roomReferences = _learningRoomGateway.LoadAll();
            var availableRooms = roomReferences.Select(reference => _learningRoomGateway.Load(reference))
                .Where(room => room.StartDate > DateTime.Now).ToList();

            return new GetResponse
            {
                LearningRooms = availableRooms.Select(room => new LearningRoomModel
                {
                    RoomId = room.Reference.Code,
                    CreatedOn = room.CreatedOn.ToString("f"),
                    CreatedBy = room.CreatedBy.Code,
                    EndDate = room.EndDate.ToString("f"),
                    LearningContent = room.LearningContent,
                    Place = room.Place,
                    ParticipantCount = room.ParticipantCount,
                    StartDate = room.StartDate.ToString("f"),
                    Title = room.Title
                }).ToList()
            };
        }
    }
}

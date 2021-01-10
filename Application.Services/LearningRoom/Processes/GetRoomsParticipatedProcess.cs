using Application.LearningRoom;
using Application.Services.LearningRoom.Contracts;
using Common.Core.DependencyInjection;
using Domain.Services.LearningRoom.Gateways;
using Domain.Services.LoginToken;
using System.Linq;

namespace Application.Services.LearningRoom.Processes
{
    [ServiceLocate(typeof(IGetRoomsParticipatedProcess))]
    public class GetRoomsParticipatedProcess : IGetRoomsParticipatedProcess
    {
        private const string DateFormat = "yyyy-MM-dd HH:mm";

        private readonly ILoginTokenGateway _loginTokenGateway;
        private readonly ILearningRoomGateway _learningRoomGateway;

        public GetRoomsParticipatedProcess(
            ILoginTokenGateway loginTokenGateway,
            ILearningRoomGateway learningRoomGateway)
        {
            _loginTokenGateway = loginTokenGateway;
            _learningRoomGateway = learningRoomGateway;
        }

        public GetResponse Get(string loginTokenCode)
        {
            var loginToken = _loginTokenGateway.Get(loginTokenCode);
            var rooms = _learningRoomGateway.LoadAll().
                Select(reference => _learningRoomGateway.Load(reference))
                .Where(room => room.Participants.Any(p => p.User.Equals(loginToken.OpenId)))
                .ToList();

            return new GetResponse
            {
                LearningRooms = rooms.Select(room => new LearningRoomModel
                {
                    RoomId = room.Reference.Code,
                    CreatedOn = room.CreatedOn.ToString(DateFormat),
                    CreatedBy = room.CreatedBy.Code,
                    EndDate = room.EndDate.ToString(DateFormat),
                    LearningContent = room.LearningContent,
                    Place = room.Place,
                    ParticipantCount = room.ParticipantCount,
                    StartDate = room.StartDate.ToString(DateFormat),
                    Title = room.Title,
                    CurrentParticipantCount = room.CurrentParticipantCount
                }).ToList()
            };
        }
    }
}

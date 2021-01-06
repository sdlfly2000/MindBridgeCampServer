using Application.LearningRoom;
using Common.Core.DependencyInjection;
using Domain.LearningRoom;
using Domain.Services.LearningRoom.Gateways;
using Domain.Services.User;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services.LearningRoom.Processes
{
    [ServiceLocate(typeof(IGetParticipantsProcess))]
    public class GetParticipantsProcess : IGetParticipantsProcess
    {
        private readonly ILearningRoomGateway _learningRoomGateway;
        private readonly IUserGateway _userGateway;

        public GetParticipantsProcess(
            ILearningRoomGateway learningRoomGateway,
            IUserGateway userGateway)
        {
            _learningRoomGateway = learningRoomGateway;
            _userGateway = userGateway;
        }

        public IList<ParticipantModel> Get(string roomId)
        {
            var room = _learningRoomGateway.Load(new RoomReference(roomId));

            var participantCodes = room.Participants.Select(p => p.User.Code).ToList();

            var participants = participantCodes.Select(p => _userGateway.Load(p)).ToList();

            return participants.Select(p => new ParticipantModel
            {
                Name = p.Name,
                NickName = p.NickName,
                Gender = (int)p.Gender
            }).ToList();
        }
    }
}

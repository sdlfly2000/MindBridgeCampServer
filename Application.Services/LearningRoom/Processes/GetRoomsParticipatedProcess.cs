using System;
using System.Collections.Generic;
using System.Linq;
using Application.LearningRoom;
using Common.Core.DependencyInjection;
using Domain.LearningRoom;
using Domain.Services.LearningRoom.Gateways;
using Domain.Services.LoginToken;
using Domain.User;

namespace Application.Services.LearningRoom.Processes
{
    [ServiceLocate(typeof(IGetRoomsParticipatedProcess))]
    public class GetRoomsParticipatedProcess : IGetRoomsParticipatedProcess
    {
        private const string DateFormat = "yyyy-MM-dd HH:mm";

        private readonly ILoginTokenGateway _loginTokenGateway;
        private readonly ILearningRoomWithSignInGateway _learningRoomWithSignInGateway;

        public GetRoomsParticipatedProcess(
            ILoginTokenGateway loginTokenGateway,
            ILearningRoomWithSignInGateway learningRoomWithSignInGateway)
        {
            _loginTokenGateway = loginTokenGateway;
            _learningRoomWithSignInGateway = learningRoomWithSignInGateway;
        }

        public IList<LearningRoomModel> Get(string loginTokenCode)
        {
            var user = _loginTokenGateway.Get(loginTokenCode);
            var rooms = _learningRoomWithSignInGateway.LoadByParticipant(user.OpenId);

            return rooms.Select(room => new LearningRoomModel
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
                CurrentParticipantCount = room.CurrentParticipantCount,                
                Status = MapStatus(room),
                IsSignIn = MapIsSignIn(room, user.OpenId)
            }).ToList();
        }

        #region Private Methods

        private LearningRoomStatus MapStatus(ILearningRoomWithSignIn room)
        {
            var currentDateTime = DateTime.Now;

            if (currentDateTime < room.StartDate)
            {
                return LearningRoomStatus.NotStart;
            }

            if (room.StartDate < currentDateTime && currentDateTime < room.EndDate)
            {
                return LearningRoomStatus.InProgress;
            }

            return LearningRoomStatus.Complete;
        }

        private bool MapIsSignIn(ILearningRoomWithSignIn room, UserReference user)
        {
            return room.SignIns.Any(s => s.Participant.Equals(user));
        }

        #endregion
    }
}

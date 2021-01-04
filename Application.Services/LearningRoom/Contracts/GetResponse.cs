using Core;
using System.Collections.Generic;
using Application.LearningRoom;

namespace Application.Services.LearningRoom.Contracts
{
    public class GetResponse
    {
        public GetResponse()
        {
            LearningRooms = new List<LearningRoomModel>();
            ValidationResults = new List<BaseValidationResult>();
        }

        public IList<LearningRoomModel> LearningRooms { get; set; }

        public IList<BaseValidationResult> ValidationResults { get; set; }
    }
}

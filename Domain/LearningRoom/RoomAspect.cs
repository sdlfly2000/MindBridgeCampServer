using Domain.User;
using System;
using System.Collections.Generic;

namespace Domain.LearningRoom
{
    public class RoomAspect : IRoomAspect
    {
        public RoomReference Reference { get; set; }
        public string Title { get; set; }
        public string LearningContent { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ParticipantCount { get; set; }
        public IList<Participant> Participants { get; set; }
        public string Place { get; set; }
        public UserReference CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}

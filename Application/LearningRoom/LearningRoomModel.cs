using System;

namespace Application.LearningRoom
{
    public class LearningRoomModel
    {
        public string RoomId { get; set; }

        public string Title { get; set; }

        public string LearningContent { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int ParticipantCount { get; set; }

        public string Place { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}

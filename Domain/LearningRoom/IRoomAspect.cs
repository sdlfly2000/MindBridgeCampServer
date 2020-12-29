using System;
using System.Collections.Generic;
using Domain.User;

namespace Domain.LearningRoom
{
    public interface IRoomAspect
    {
        RoomReference Reference { get; set; }
        string Title { get; set; }
        string LearningContent { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        int ParticipantCount { get; set; }
        IList<Participant> Participants { get; set; }
        string Place { get; set; }
        UserReference CreatedBy { get; set; }
        DateTime CreatedOn { get; set; }
    }
}

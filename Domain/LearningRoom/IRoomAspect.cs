using System;
using System.Collections.Generic;
using Domain.User;
using Common.Core.AOP;

namespace Domain.LearningRoom
{
    public interface IRoomAspect : ICacheAspect
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
        int CurrentParticipantCount { get; }
    }
}

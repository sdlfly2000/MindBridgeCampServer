using System;
using Domain.User;

namespace Domain.LearningRoom
{
    public interface IChatAspect
    {
        ChatReference Reference { get; set; }
        RoomReference Room { get; set; }
        UserReference CreatedBy { get; set; }
        DateTime CreatedOn { get; set; }
        string Content { get; set; }
    }
}

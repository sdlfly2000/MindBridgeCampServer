using Domain.User;
using System;

namespace Domain.LearningRoom
{
    public class ChatAspect : IChatAspect
    {
        public ChatReference Reference { get; set; }
        public RoomReference Room { get; set; }
        public UserReference CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Content { get; set; }
    }
}

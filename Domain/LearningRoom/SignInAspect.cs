using Domain.User;
using System;

namespace Domain.LearningRoom
{
    public class SignInAspect : ISignInAspect
    {
        public SignInReference Reference { get; set; }
        public RoomReference Room { get; set; }
        public DateTime SignInOn { get; set; }
        public UserReference Participant { get; set; }
    }
}

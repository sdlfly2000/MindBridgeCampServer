using System;
using Domain.User;

namespace Domain.LearningRoom
{
    public interface ISignInAspect
    {
        SignInReference Reference { get; set; }
        RoomReference Room { get; set; }
        DateTime SignInOn { get; set; }
        UserReference Participant { get; set; }
    }
}

using System.Collections.Generic;

namespace Domain.LearningRoom
{
    public interface ILearningRoomWithSignIn : IRoomAspect, IList<ISignInAspect>
    {
    }
}

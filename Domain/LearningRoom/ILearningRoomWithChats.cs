using System.Collections.Generic;

namespace Domain.LearningRoom
{
    public interface ILearningRoomWithChats : IRoomAspect, IList<IChatAspect>
    {
    }
}

using Domain.LearningRoom;
using Domain.User;

namespace Domain.Services.LearningRoom.Synchronizors.Persistors
{
    public interface IParticipantPersistor
    {
        void Update(UserReference participant, RoomReference room);
    }
}

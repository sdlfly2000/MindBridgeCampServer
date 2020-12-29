using Domain.LearningRoom;

namespace Domain.Services.LearningRoom.Synchronizors.Persistors
{
    public interface IParticipantPersistor
    {
        void Add(IParticipant participant);

        void Update(IParticipant participant);
    }
}

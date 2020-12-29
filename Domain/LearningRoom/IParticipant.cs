using Domain.User;

namespace Domain.LearningRoom
{
    public interface IParticipant
    {
        ParticipantReference Reference { get; set; }

        RoomReference Room { get; set; }

        UserReference User { get; set; }

        bool IsDeleted { get; set; }
    }
}

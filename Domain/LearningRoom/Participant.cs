using Domain.User;

namespace Domain.LearningRoom
{
    public class Participant : IParticipant
    {
        public ParticipantReference Reference { get; set; }
        public RoomReference Room { get; set; }
        public UserReference User { get; set; }
        public bool IsDeleted { get; set; }
    }
}

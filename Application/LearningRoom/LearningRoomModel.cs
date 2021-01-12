using System.Runtime.Serialization;

namespace Application.LearningRoom
{
    public class LearningRoomModel
    {
        public string RoomId { get; set; }

        public string Title { get; set; }

        public string LearningContent { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public int ParticipantCount { get; set; }

        public string Place { get; set; }

        public string CreatedBy { get; set; }

        public string CreatedOn { get; set; }

        public int CurrentParticipantCount { get; set; }

        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public LearningRoomStatus Status { get; set; }

        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public bool IsSignIn { get; set; }
    }
}

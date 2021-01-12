namespace Application.LearningRoom
{
    public class LearningRoomWithStatusModel
    {
        public LearningRoomModel LearningRoom { get; set; }

        public LearningRoomStatus Status { get; set; }

        public bool IsSignIn { get; set; }
    }
}

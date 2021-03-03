using System;

namespace Application.LearningRoom
{
    [Serializable]
    public class LearningRoomMessageModel
    {
        public string CreatedByNickName { get; set; }
        public string Content { get; set; }
        public bool IsCreatedByRequester { get; set; }
    }
}

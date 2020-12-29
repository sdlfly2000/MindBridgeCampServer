using Domain.User;
using System;
using System.Collections.Generic;

namespace Domain.LearningRoom
{
    public class LearningRoomWithChats : ILearningRoomWithChats
    {
        private readonly IRoomAspect _roomAspect;

        public LearningRoomWithChats(IRoomAspect roomAspect)
        {
            _roomAspect = roomAspect;
            ChatAspects = new List<IChatAspect>();
        }

        public IList<IChatAspect> ChatAspects { get;set; }

        public RoomReference Reference 
        {
            get { return _roomAspect.Reference; }
            set { _roomAspect.Reference = value; } 
        }

        public string Title
        {
            get { return _roomAspect.Title; }
            set { _roomAspect.Title = value; }
        }

        public string LearningContent
        {
            get { return _roomAspect.LearningContent; }
            set { _roomAspect.LearningContent = value; }
        }

        public DateTime StartDate
        {
            get { return _roomAspect.StartDate; }
            set { _roomAspect.StartDate = value; }
        }

        public DateTime EndDate
        {
            get { return _roomAspect.EndDate; }
            set { _roomAspect.EndDate = value; }
        }

        public int ParticipantCount
        {
            get { return _roomAspect.ParticipantCount; }
            set { _roomAspect.ParticipantCount = value; }
        }

        public IList<Participant> Participants
        {
            get { return _roomAspect.Participants; }
            set { _roomAspect.Participants = value; }
        }

        public string Place
        {
            get { return _roomAspect.Place; }
            set { _roomAspect.Place = value; }
        }

        public UserReference CreatedBy
        {
            get { return _roomAspect.CreatedBy; }
            set { _roomAspect.CreatedBy = value; }
        }

        public DateTime CreatedOn
        {
            get { return _roomAspect.CreatedOn; }
            set { _roomAspect.CreatedOn = value; }
        }
    }
}

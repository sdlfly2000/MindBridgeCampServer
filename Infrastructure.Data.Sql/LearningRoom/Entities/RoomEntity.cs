using Infrastructure.Data.Sql.Persistence;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Data.Sql.LearningRoom.Entities
{
    public class RoomEntity : IEntity
    {
        [Key]
        public string roomId { get; set; }

        public string title { get; set; }

        public string learningContent { get; set; }

        public DateTime startDate { get; set; }

        public DateTime endDate { get; set; }

        public int participantCount { get; set; }

        public string place { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}

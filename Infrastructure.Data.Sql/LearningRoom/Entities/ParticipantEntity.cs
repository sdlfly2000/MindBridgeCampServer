using Common.Core.Data.Sql;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Data.Sql.LearningRoom.Entities
{
    public class ParticipantEntity : IEntity
    {
        [Key]
        public string participantId { get; set; }

        public string roomId { get; set; }

        public string userId { get; set; }

        public bool isDeleted { get; set; }
    }
}

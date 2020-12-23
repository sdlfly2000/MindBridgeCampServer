using Infrastructure.Data.Sql.Persistence;
using System;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Data.Sql.LearningRoom.Entities
{
    public class ChatEntity : IEntity
    {
        [Key]
        public string chatId { get; set; }

        public string roomId { get; set; }

        public string createdBy { get; set; }

        public DateTime createdOn { get; set; }

        public string content { get; set; }
    }
}

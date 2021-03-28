using Common.Core.Data.Sql;
using System;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Data.Sql.Note.Entities
{
    public class CommentEntity : IEntity
    {
        [Key]
        public string commentId { get; set; }

        public string note { get; set; }

        public DateTime createdOn { get; set; }

        public string createdBy { get; set; }

        public string content { get; set; }

        public int rate { get; set; }
    }
}

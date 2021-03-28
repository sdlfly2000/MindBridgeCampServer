using Common.Core.Data.Sql;
using System;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Data.Sql.Note.Entities
{
    public class TagEntity : IEntity
    {
        [Key]
        public string tagId { get; set; }

        public string note { get; set; }

        public DateTime createdOn { get; set; }

        public string createdBy { get; set; }

        public string caption { get; set; }
    }
}

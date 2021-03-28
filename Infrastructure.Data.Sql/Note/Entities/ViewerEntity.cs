using Common.Core.Data.Sql;
using System;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Data.Sql.Note.Entities
{
    public class ViewerEntity : IEntity
    {
        [Key]
        public string viewerId { get; set; }

        public string noteId { get; set; }

        public DateTime createdOn { get; set; }

        public string createdBy { get; set; }
    }
}

using Common.Core.Data.Sql;
using System;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Data.Sql.Note.Entities
{
    public class NoteEntity : IEntity
    {
        [Key]
        public string noteId { get; set; }

        public string createdBy { get; set; }

        public DateTime createdOn { get; set; }

        public string content { get; set; }

        public string title { get; set; }
    }
}

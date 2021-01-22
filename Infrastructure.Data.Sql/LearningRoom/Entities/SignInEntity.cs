using Common.Core.Data.Sql;
using System;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Data.Sql.LearningRoom.Entities
{
    public class SignInEntity : IEntity
    {
        [Key]
        public string signInId { get; set; }

        public string roomId { get; set; }

        public DateTime signInOn { get; set; }

        public string participant { get; set; }
    }
}

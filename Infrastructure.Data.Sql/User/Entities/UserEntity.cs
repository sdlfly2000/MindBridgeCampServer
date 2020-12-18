using Infrastructure.Data.Sql.Persistence;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Data.Sql.User.Entities
{
    public class UserEntity : IEntity
    {
        [Key]
        public string userId { get; set; }

        public int? gender { get; set; }

        public string name { get; set; }

        public string majorIn { get; set; }

        public int? height { get; set; }

        public int? weight { get; set; }

        public string studyContent { get; set; }

        public string expectationAfterGraduation { get; set; }

        public IList<HobbyEntity> hobbies { get; set; }
    }
}

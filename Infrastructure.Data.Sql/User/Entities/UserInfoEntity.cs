using Infrastructure.Data.Sql.Persistence;
using System;

namespace Infrastructure.Data.Sql.User.Entities
{
    public class UserInfoEntity : IEntity
    {
        public Guid openId { get; set; }

        public string nickName { get; set; }

        public string avatarUrl { get; set; }

        public string country { get; set; }

        public string province { get; set; }

        public string city { get; set; }

        public string language { get; set; }
    }
}

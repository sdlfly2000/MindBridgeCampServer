using System;

namespace Domain.User
{
    public class UserInfoAspect : IUserInfoAspect
    {
        public Guid OpenId { get; set; }

        public string NickName { get; set; }

        public string AvatarUrl { get; set; }

        public string Country { get; set; }

        public string Province { get; set; }

        public string City { get; set; }

        public string Language { get; set; }
    }
}

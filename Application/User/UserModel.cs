using Domain.User;
using System;
using System.Collections.Generic;

namespace Application.User
{
    public class UserModel
    {
        public Guid UserId { get; set; }

        public GenderType Gender { get; set; }

        public string Name { get; set; }

        public string MajorIn { get; set; }

        public int? Height { get; set; }

        public int? Weight { get; set; }

        public string StudyContent { get; set; }

        public string ExpectationAfterGraduation { get; set; }

        public IList<Hobby> Hobbies { get; set; }

        public Guid OpenId { get; set; }

        public string NickName { get; set; }

        public string AvatarUrl { get; set; }

        public string Country { get; set; }

        public string Province { get; set; }

        public string City { get; set; }

        public string Language { get; set; }
    }
}

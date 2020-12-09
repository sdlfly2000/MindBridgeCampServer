using System;
using System.Collections.Generic;

namespace Domain.User
{
    public class UserAspect : IUserAspect
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
    }
}

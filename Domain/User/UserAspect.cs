﻿namespace Domain.User
{
    public class UserAspect : IUserAspect
    {
        public UserReference UserId { get; set; }
        public GenderType Gender { get; set; }
        public string Name { get; set; }
        public string MajorIn { get; set; }
        public int? Height { get; set; }
        public int? Weight { get; set; }
        public string StudyContent { get; set; }
        public string ExpectationAfterGraduation { get; set; }
        public string Hobby { get; set; }
    }
}

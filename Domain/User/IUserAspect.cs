using System;
using System.Collections.Generic;

namespace Domain.User
{
    public interface IUserAspect
    {
        Guid UserId { get; set; }

        GenderType Gender { get; set; }

        string Name { get; set; }

        string MajorIn { get; set; }

        int? Height { get; set; }

        int? Weight { get; set; }

        string StudyContent { get; set; }

        string ExpectationAfterGraduation { get; set; }

        IList<Hobby> Hobbies { get; set; }
    }
}

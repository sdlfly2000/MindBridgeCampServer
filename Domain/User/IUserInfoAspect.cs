using System;

namespace Domain.User
{
    public interface IUserInfoAspect
    {
        Guid OpenId { get; set; }

        string NickName { get; set; }

        string AvatarUrl { get; set; }

        string Country { get; set; }

        string Province { get; set; }
        
        string City { get; set; }

        string Language { get; set; }
    }
}

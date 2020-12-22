using Common.Core.AOP;

namespace Domain.User
{
    public interface IUserInfoAspect : ICacheAspect
    {
        UserReference OpenId { get; set; }

        string NickName { get; set; }

        string AvatarUrl { get; set; }

        string Country { get; set; }

        string Province { get; set; }
        
        string City { get; set; }

        string Language { get; set; }
    }
}

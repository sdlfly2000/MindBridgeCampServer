namespace Domain.User
{
    public class UserInfoAspect : IUserInfoAspect
    {
        public UserReference OpenId { get; set; }

        public string NickName { get; set; }

        public string AvatarUrl { get; set; }

        public string Country { get; set; }

        public string Province { get; set; }

        public string City { get; set; }

        public string Language { get; set; }

        public string Code => OpenId.Code;
    }
}

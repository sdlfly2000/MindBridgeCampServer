using Domain.LoginToken;
using System.Collections.Generic;

namespace Domain.User
{
    public class UserDomain : IUser
    {
        private readonly IUserAspect _userAspect;
        private readonly IUserInfoAspect _userInfoAspect;

        public UserDomain(
            IUserAspect userAspct, 
            IUserInfoAspect userInfoAspect)
        {
            _userAspect = userAspct;
            _userInfoAspect = userInfoAspect;
        }

        public OpenIdReference UserId 
        {
            get { return _userAspect.UserId; } 
            set { _userAspect.UserId = value; }
        }

        public GenderType Gender
        {
            get { return _userAspect.Gender; }
            set { _userAspect.Gender = value; }
        }

        public string Name
        {
            get { return _userAspect.Name; }
            set { _userAspect.Name = value; }
        }

        public string MajorIn
        {
            get { return _userAspect.MajorIn; }
            set { _userAspect.MajorIn = value; }
        }

        public int? Height
        {
            get { return _userAspect.Height; }
            set { _userAspect.Height = value; }
        }

        public int? Weight
        {
            get { return _userAspect.Weight; }
            set { _userAspect.Weight = value; }
        }

        public string StudyContent
        {
            get { return _userAspect.StudyContent; }
            set { _userAspect.StudyContent = value; }
        }
        public string ExpectationAfterGraduation
        {
            get { return _userAspect.ExpectationAfterGraduation; }
            set { _userAspect.ExpectationAfterGraduation = value; }
        }

        public IList<Hobby> Hobbies
        {
            get { return _userAspect.Hobbies; }
            set { _userAspect.Hobbies = value; }
        }

        public OpenIdReference OpenId
        {
            get { return _userInfoAspect.OpenId; }
            set { _userInfoAspect.OpenId = value; }
        }

        public string NickName
        {
            get { return _userInfoAspect.NickName; }
            set { _userInfoAspect.NickName = value; }
        }

        public string AvatarUrl
        {
            get { return _userInfoAspect.AvatarUrl; }
            set { _userInfoAspect.AvatarUrl = value; }
        }

        public string Country
        {
            get { return _userInfoAspect.Country; }
            set { _userInfoAspect.Country = value; }
        }

        public string Province
        {
            get { return _userInfoAspect.Province; }
            set { _userInfoAspect.Province = value; }
        }

        public string City
        {
            get { return _userInfoAspect.City; }
            set { _userInfoAspect.City = value; }
        }

        public string Language
        {
            get { return _userInfoAspect.Language; }
            set { _userInfoAspect.Language = value; }
        }

        public string Code => "User" + UserId.Code;
    }
}

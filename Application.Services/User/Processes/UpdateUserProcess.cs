using Application.User;
using Common.Core.DependencyInjection;
using Domain.Services.User;
using Domain.User;
using Domain.Services.LoginToken;

namespace Application.Services.User.Processes
{
    [ServiceLocate(typeof(IUpdateUserProcess))]
    public class UpdateUserProcess : IUpdateUserProcess
    {
        private readonly IUserGateway _userGateway;
        private readonly ILoginTokenGateway _loginTokenGateway;

        public UpdateUserProcess(
            IUserGateway userGateway,
            ILoginTokenGateway loginTokenGateway)
        {
            _userGateway = userGateway;
            _loginTokenGateway = loginTokenGateway;
        }

        public void UpdateUserInfo(string loginToken, UserModel model)
        {
            var token = _loginTokenGateway.Get(loginToken);

            var user = new UserDomain(
               new UserAspect(),
               new UserInfoAspect
               {
                   OpenId = new UserReference(token.OpenId.Code, "UserInfoAspect"),
                   NickName = model.NickName,
                   AvatarUrl = model.AvatarUrl,
                   City = model.City,
                   Country = model.Country,
                   Language = model.Language,
                   Province = model.Province
               });

            _userGateway.SaveUserInfo(user);
        }

        public void UpdateUser(string loginToken, UserModel model)
        {
            var token = _loginTokenGateway.Get(loginToken);

            var user = new UserDomain(
                new UserAspect
                {
                    UserId = new UserReference(token.OpenId.Code, "UserAspect"),
                    ExpectationAfterGraduation = model.ExpectationAfterGraduation,
                    Gender = MapInt(model.Gender) == null
                        ? GenderType.Unknown
                        : (GenderType)MapInt(model.Gender),
                    Height = MapInt(model.Height),
                    Weight = MapInt(model.Weight),
                    MajorIn = model.MajorIn,
                    Name = model.Name,
                    StudyContent = model.StudyContent,
                    Hobby = model.Hobby
                },
                new UserInfoAspect());

            _userGateway.SaveUser(user);
        }

        #region Private Methods

        private int? MapInt(string value)
        {
            return string.IsNullOrEmpty(value)
                ? (int?)null
                : int.Parse(value);
        }

        #endregion
    }
}

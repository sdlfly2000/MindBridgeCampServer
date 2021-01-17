using Application.Services.User.Contracts;
using Application.User;
using Common.Core.DependencyInjection;
using Domain.Services.LoginToken;
using Domain.Services.User;
using Domain.User;

namespace Application.Services.User.Processes
{
    [ServiceLocate(typeof(IGetUserProcess))]
    public class GetUserProcess : IGetUserProcess
    {
        private readonly IUserGateway _userGateway;
        private readonly ILoginTokenGateway _loginTokenGateway;

        public GetUserProcess(
            IUserGateway userGateway,
            ILoginTokenGateway loginTokenGateway)
        {
            _userGateway = userGateway;
            _loginTokenGateway = loginTokenGateway;
        }

        public GetResponse Get(GetByIdRequest request)
        {
             return new GetResponse
            {
                User = Map(_userGateway.Load(request.UserId))
            };
        }

        public GetResponse Get(GetByLoginTokenRequest request)
        {
            var loginToken = _loginTokenGateway.Get(request.LoginToken);
            return new GetResponse
            {
                User = Map(_userGateway.Load(loginToken.OpenId.Code))
            };
        }

        #region Private Methods

        private UserModel Map(IUser user)
        {
            return new UserModel
            {
                AvatarUrl = user.AvatarUrl,
                City = user.City,
                Country = user.Country,
                ExpectationAfterGraduation = user.ExpectationAfterGraduation,
                Gender = user.Gender.ToString(),
                Height = user.Height.Value.ToString(),
                Weight = user.Weight.Value.ToString(),
                Hobby = user.Hobby,
                Language = user.Language,
                MajorIn = user.MajorIn,
                Name = user.Name,
                NickName = user.NickName,
                OpenId = user.OpenId.Code,
                Province = user.Province,
                StudyContent = user.StudyContent,
                UserId = user.UserId.Code
            };
        }

        #endregion
    }
}

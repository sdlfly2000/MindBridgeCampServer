using Application.User;
using Common.Core.DependencyInjection;
using Domain.Services.User;
using Domain.User;
using System;
using System.Linq;

namespace Application.Services.User.Processes
{
    using Domain.Services.LoginToken;
    using System.Collections.Generic;

    [ServiceLocate(typeof(IAddUserProcess))]
    public class AddUserProcess : IAddUserProcess
    {
        private readonly IUserGateway _userGateway;
        private readonly ILoginTokenGateway _loginTokenGateway;

        public AddUserProcess(
            IUserGateway userGateway,
            ILoginTokenGateway loginTokenGateway)
        {
            _userGateway = userGateway;
            _loginTokenGateway = loginTokenGateway;
        }

        public void Add(string loginToken, UserModel model)
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
                new UserInfoAspect
                {
                    OpenId = new UserReference(token.OpenId.Code, "UserInfo"),
                    NickName = model.NickName,
                    AvatarUrl = model.AvatarUrl,
                    City = model.City,
                    Country = model.Country,
                    Language = model.Language,
                    Province = model.Province
                });

            _userGateway.Add(user);
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

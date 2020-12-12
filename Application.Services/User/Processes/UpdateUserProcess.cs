using Application.Services.User.Contracts;
using Application.User;
using Common.Core.DependencyInjection;
using Domain.Services.User;
using Domain.User;

namespace Application.Services.User.Processes
{
    [ServiceLocate(typeof(IUpdateUserProcess))]
    public class UpdateUserProcess : IUpdateUserProcess
    {
        private readonly IUserGateway _userGateway;

        public UpdateUserProcess(IUserGateway userGateway)
        {
            _userGateway = userGateway;
        }

        public GetResponse Update(UserModel model)
        {
            var user = new UserDomain(
               new UserAspect
               {
                   UserId = model.UserId,
                   ExpectationAfterGraduation = model.ExpectationAfterGraduation,
                   Gender = model.Gender,
                   Height = model.Height,
                   Weight = model.Weight,
                   MajorIn = model.MajorIn,
                   Name = model.Name,
                   StudyContent = model.StudyContent,
                   Hobbies = model.Hobbies
               },
               new UserInfoAspect
               {
                   OpenId = model.OpenId,
                   NickName = model.NickName,
                   AvatarUrl = model.AvatarUrl,
                   City = model.City,
                   Country = model.Country,
                   Language = model.Language,
                   Province = model.Province
               });

            _userGateway.Save(user);

            return new GetResponse();
        }
    }
}

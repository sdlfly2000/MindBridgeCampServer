using Application.Services.User.Contracts;
using Application.Services.User.Processes;
using Application.User;
using Common.Core.DependencyInjection;

namespace Application.Services.User
{
    [ServiceLocate(typeof(IUserService))]
    public class UserService : IUserService
    {
        private readonly IAddUserProcess _addUserProcess;
        private readonly IGetUserProcess _getUserProcess;
        private readonly IUpdateUserProcess _updateUserProcess;

        public UserService(
            IAddUserProcess addUserProcess,
            IGetUserProcess getUserProcess,
            IUpdateUserProcess updateUserProcess)
        {
            _addUserProcess = addUserProcess;
            _getUserProcess = getUserProcess;
            _updateUserProcess = updateUserProcess;
        }

        public GetResponse Add(UserModel model)
        {
            return _addUserProcess.Add(model);
        }

        public GetResponse Get(GetByIdRequest request)
        {
            return _getUserProcess.Get(request);
        }

        public GetResponse Get(GetByLoginTokenRequest request)
        {
            return _getUserProcess.Get(request);
        }

        public GetResponse Update(UserModel model)
        {
            return _updateUserProcess.Update(model);
        }

        public void UpdateUserInfo(UserModel model)
        {
            _updateUserProcess.UpdateUserInfo(model);
        }
    }
}

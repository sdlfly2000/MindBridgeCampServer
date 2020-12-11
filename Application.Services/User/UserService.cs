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

        public UserService(
            IAddUserProcess addUserProcess,
            IGetUserProcess getUserProcess)
        {
            _addUserProcess = addUserProcess;
            _getUserProcess = getUserProcess;
        }

        public GetResponse Add(UserModel model)
        {
            return _addUserProcess.Add(model);
        }

        public GetResponse Get(GetByIdRequest request)
        {
            return _getUserProcess.Get(request);
        }
    }
}

using Application.Services.User.Contracts;
using Common.Core.DependencyInjection;
using Domain.Services.User;

namespace Application.Services.User
{
    [ServiceLocate(typeof(IUserService))]
    public class UserService : IUserService
    {
        private readonly IUserGateway _userGateway;

        public UserService(
            IUserGateway userGateway)
        {
            _userGateway = userGateway;
        }

        public GetResponse Get(GetByIdRequest request)
        {
            var user = _userGateway.Load(request.UserId);

            return new GetResponse
            {
                User = user
            };
        }
    }
}

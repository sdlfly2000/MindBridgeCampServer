using Application.Services.User.Contracts;
using Common.Core.DependencyInjection;
using Domain.Services.User;

namespace Application.Services.User.Processes
{
    [ServiceLocate(typeof(IGetUserProcess))]
    public class GetUserProcess : IGetUserProcess
    {
        private readonly IUserGateway _userGateway;

        public GetUserProcess(IUserGateway userGateway)
        {
            _userGateway = userGateway;
        }

        public GetResponse Get(GetByIdRequest request)
        {
             return new GetResponse
            {
                User = _userGateway.Load(request.UserId)
            };
        }
    }
}

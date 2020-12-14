using Application.Services.User.Contracts;

namespace Application.Services.User.Processes
{
    public interface IGetUserProcess
    {
        GetResponse Get(GetByIdRequest request);

        GetResponse Get(GetByLoginTokenRequest request);
    }
}

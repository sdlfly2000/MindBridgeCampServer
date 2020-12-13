using Domain.AccessToken;

namespace Domain.Services.AccessToken.Loaders.Mappers
{
    public interface IAccessTokenAspectMapper
    {
        IAccessTokenAspect Map(AccessTokenEntity entity);
    }
}

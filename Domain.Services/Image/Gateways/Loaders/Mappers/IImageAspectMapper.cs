using Domain.Image;
using Infrastructure.Data.Sql.Image.Entities;

namespace Domain.Services.Image.Gateways.Loaders.Mappers
{
    public interface IImageAspectMapper
    {
        IImageAspect Map(ImageEntity entity);
    }
}

using Common.Core.DependencyInjection;
using Domain.Image;
using Domain.User;
using Infrastructure.Data.Sql.Image.Entities;

namespace Domain.Services.Image.Gateways.Loaders.Mappers
{
    [ServiceLocate(typeof(IImageAspectMapper))]
    public class ImageAspectMapper : IImageAspectMapper
    {
        public IImageAspect Map(ImageEntity entity)
        {
            return entity.Equals(default(ImageEntity))
                ? default(ImageAspect)
                : new ImageAspect
                    {
                        Reference = new ImageReference(entity.imageId),
                        Extention = entity.extension,
                        CreatedBy = new UserReference(entity.createdBy),
                        CreatedOn = entity.createdOn,
                        Status = (ImageStatus)entity.status
                    };
        }
    }
}

using Common.Core.Data.Sql;
using Common.Core.DependencyInjection;
using Domain.Image;
using Domain.Services.Image.Gateways.Loaders;
using Infrastructure.Data.Sql.Image.Entities;

namespace Domain.Services.Image.Persistors.Synchronizors
{
    [ServiceLocate(typeof(IImageAspectSynchronizor))]
    public class ImageAspectSynchronizor : Synchronizor<IImageAspect, ImageEntity>, IImageAspectSynchronizor
    {
        public ImageAspectSynchronizor(
            IUnitOfWork<ImageEntity> uow,
            IImageAspectLoader imageAspectLoader) : base(uow, imageAspectLoader)
        {
        }

        protected override ImageEntity Map(IImageAspect aspect)
        {
            return new ImageEntity
            {
                imageId = aspect.Reference.Code,
                createdBy = aspect.CreatedBy.Code,
                createdOn = aspect.CreatedOn,
                extension = aspect.Extention,
                status = (int)aspect.Status
            };
        }
    }
}

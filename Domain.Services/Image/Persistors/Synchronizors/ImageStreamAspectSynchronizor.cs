using Common.Core.DependencyInjection;
using Domain.Image;
using Infrastructure.Data.Sql.Image.Entities;
using Infrastructure.File.Image;

namespace Domain.Services.Image.Persistors.Synchronizors
{
    [ServiceLocate(typeof(IImageStreamAspectSynchronizor))]
    public class ImageStreamAspectSynchronizor : IImageStreamAspectSynchronizor
    {
        private readonly IImageStorage _imageStorage;

        public ImageStreamAspectSynchronizor(IImageStorage imageStorage)
        {
            _imageStorage = imageStorage;
        }

        public void Synchronize(IImage image)
        {
            var request = new ImageSaveRequest
            {
                Entity = new ImageEntity
                {
                    imageId = image.Reference.Code,
                    createdBy = image.CreatedBy.Code,
                    createdOn = image.CreatedOn,
                    extension = image.Extention,
                    status = (int)image.Status
                },
                ImageStream = image.ImageStream
            };

            _imageStorage.Save(request);
        }
    }
}

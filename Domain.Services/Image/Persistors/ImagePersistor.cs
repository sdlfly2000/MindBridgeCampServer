using Common.Core.Data.Sql;
using Common.Core.DependencyInjection;
using Domain.Image;
using Domain.Services.Image.Persistors.Synchronizors;

namespace Domain.Services.Image.Persistors
{
    [ServiceLocate(typeof(IImagePersistor))]
    public class ImagePersistor : IImagePersistor
    {
        private readonly IImageAspectSynchronizor _imageAspectSynchronizor;
        private readonly IImageStreamAspectSynchronizor _streamAspectSynchronizor;
        private readonly IPersistence _persistence;

        public ImagePersistor(
            IPersistence persistence,
            IImageAspectSynchronizor imageAspectSynchronizor,
            IImageStreamAspectSynchronizor streamAspectSynchronizor)
        {
            _persistence = persistence;
            _imageAspectSynchronizor = imageAspectSynchronizor;
            _streamAspectSynchronizor = streamAspectSynchronizor;
        }

        public void Persist(IImage image)
        {
            _imageAspectSynchronizor.Synchronize(image);            
            _persistence.Complete();
            _streamAspectSynchronizor.Synchronize(image);
        }
    }
}

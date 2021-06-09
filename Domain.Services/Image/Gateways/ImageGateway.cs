using Common.Core.DependencyInjection;
using Domain.Image;
using Domain.Services.Image.Gateways.Loaders;

namespace Domain.Services.Image.Gateways
{
    [ServiceLocate(typeof(IImageGateway))]
    public class ImageGateway : IImageGateway
    {
        private readonly IImageAspectLoader _imageAspectLoader;

        public ImageGateway(IImageAspectLoader imageAspectLoader)
        {
            _imageAspectLoader = imageAspectLoader;
        }

        public IImage Load(ImageReference reference)
        {
            return new ImageDomain(_imageAspectLoader.Load(reference));
        }
    }
}

using Domain.Image;

namespace Domain.Services.Image.Gateways.Loaders
{
    public interface IImageAspectLoader
    {
        IImageAspect Load(ImageReference refernce);
    }
}

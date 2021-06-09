using Domain.Image;

namespace Domain.Services.Image.Gateways
{
    public interface IImageGateway
    {
        IImage Load(ImageReference reference);
    }
}

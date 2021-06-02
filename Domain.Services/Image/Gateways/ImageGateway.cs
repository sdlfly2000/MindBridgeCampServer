using Common.Core.DependencyInjection;

namespace Domain.Services.Image.Gateways
{
    [ServiceLocate(typeof(IImageGateway))]
    public class ImageGateway : IImageGateway
    {
    }
}

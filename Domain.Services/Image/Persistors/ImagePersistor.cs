using Common.Core.DependencyInjection;

namespace Domain.Services.Image.Persistors
{
    [ServiceLocate(typeof(IImagePersistor))]
    public class ImagePersistor : IImagePersistor
    {
    }
}

using Domain.Image;

namespace Domain.Services.Image.Persistors
{
    public interface IImagePersistor
    {
        void Persist(IImage image);
    }
}

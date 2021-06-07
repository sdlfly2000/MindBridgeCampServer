using Domain.Image;

namespace Domain.Services.Image.Persistors.Synchronizors
{
    public interface IImageStreamAspectSynchronizor
    {
        void Synchronize(IImage image);
    }
}

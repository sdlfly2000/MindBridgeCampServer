using Domain.Image;

namespace Domain.Services.Image.Persistors.Synchronizors
{
    public interface IImageAspectSynchronizor
    {
        void Synchronize(IImageAspect aspect);
    }
}

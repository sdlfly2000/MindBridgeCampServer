using Domain.Note;

namespace Domain.Services.Note.Persistors.Synchronizors
{
    public interface IViewerAspectSynchronizor
    {
        void Synchronize(IViewerAspect aspect);
    }
}

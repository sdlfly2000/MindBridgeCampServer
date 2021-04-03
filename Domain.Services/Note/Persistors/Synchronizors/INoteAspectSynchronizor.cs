using Domain.Note;

namespace Domain.Services.Note.Persistors.Synchronizors
{
    public interface INoteAspectSynchronizor
    {
        void Synchronize(INoteAspect aspect);
    }
}

using Domain.Note;

namespace Domain.Services.Note.Persistors.Synchronizors
{
    public interface ITagAspectSynchronizor
    {
        void Synchronize(ITagAspect aspect);
    }
}

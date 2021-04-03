using Domain.Note;

namespace Domain.Services.Note.Persistors.Synchronizors
{
    public interface ICommentAspectSynchronizor
    {
        void Synchronize(ICommentAspect aspect);
    }
}

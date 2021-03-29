using Domain.Note;

namespace Domain.Services.Note.Gateways.Loaders
{
    public interface INoteAspectLoader
    {
        INoteAspect Load(NoteReference note);
    }
}

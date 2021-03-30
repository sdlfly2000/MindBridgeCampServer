using Domain.Note;
using System.Collections.Generic;

namespace Domain.Services.Note.Gateways.Loaders
{
    public interface ITagAspectLoader
    {
        ITagAspect Load(TagReference tag);

        IList<ITagAspect> LoadByNote(NoteReference note);
    }
}

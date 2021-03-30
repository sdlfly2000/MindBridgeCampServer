using Domain.Note;
using System.Collections.Generic;

namespace Domain.Services.Note.Gateways.Loaders
{
    public interface IViewerAspectLoader
    {
        IViewerAspect Load(ViewerReference viewer);

        IList<IViewerAspect> LoadByNote(NoteReference note);
    }
}

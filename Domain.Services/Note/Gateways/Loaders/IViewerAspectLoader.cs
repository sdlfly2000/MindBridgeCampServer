using Common.Core.Data.Sql;
using Domain.Note;
using System.Collections.Generic;

namespace Domain.Services.Note.Gateways.Loaders
{
    public interface IViewerAspectLoader : IAspectLoader<IViewerAspect>
    {
        IList<IViewerAspect> LoadByNote(NoteReference note);
    }
}

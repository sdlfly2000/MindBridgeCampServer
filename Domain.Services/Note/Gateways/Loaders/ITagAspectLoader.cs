using Common.Core.Data.Sql;
using Domain.Note;
using System.Collections.Generic;

namespace Domain.Services.Note.Gateways.Loaders
{
    public interface ITagAspectLoader : IAspectLoader<ITagAspect>
    {
        IList<ITagAspect> LoadByNote(NoteReference note);
    }
}

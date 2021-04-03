using Common.Core.Data.Sql;
using Domain.Note;
using System.Collections.Generic;

namespace Domain.Services.Note.Gateways.Loaders
{
    public interface ICommentAspectLoader : IAspectLoader<ICommentAspect>
    {
        IList<ICommentAspect> LoadByNote(NoteReference note);
    }
}

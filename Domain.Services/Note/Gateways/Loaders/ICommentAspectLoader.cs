using Domain.Note;
using System.Collections.Generic;

namespace Domain.Services.Note.Gateways.Loaders
{
    public interface ICommentAspectLoader
    {
        ICommentAspect Load(CommentReference comment);

        IList<ICommentAspect> LoadByNote(NoteReference note);
    }
}

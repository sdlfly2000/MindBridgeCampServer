using Application.Note;
using System.Collections.Generic;

namespace Application.Services.Note
{
    public interface INoteService
    {
        void CreateNote(string loginToken, NoteModel model);

        void CreateComment(string loginToken, string noteId, CommentModel model);

        void CreateTag(string loginToken, string noteId, TagModel model);

        void CreateViewer(string loginToken, string noteId);

        NoteModel Load(string noteId);

        IList<NoteModel> LoadValidNotes();
    }
}

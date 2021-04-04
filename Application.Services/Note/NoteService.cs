using Application.Note;
using Application.Services.Note.Processes;
using Common.Core.DependencyInjection;
using System;
using System.Collections.Generic;

namespace Application.Services.Note
{
    [ServiceLocate(typeof(INoteService))]
    public class NoteService : INoteService
    {
        private readonly ICreateNoteProcess _createNoteProcess;

        public NoteService(
            ICreateNoteProcess createNoteProcess)
        {
            _createNoteProcess = createNoteProcess;
        }

        public void CreateComment(string loginToken, string noteId, CommentModel model)
        {
            throw new NotImplementedException();
        }

        public void CreateNote(string loginToken, NoteModel model)
        {
            _createNoteProcess.Create(loginToken, model);
        }

        public void CreateTag(string loginToken, string noteId, TagModel model)
        {
            throw new NotImplementedException();
        }

        public void CreateViewer(string loginToken, string noteId)
        {
            throw new NotImplementedException();
        }

        public NoteModel Load(string noteId)
        {
            throw new NotImplementedException();
        }

        public IList<NoteModel> LoadValidNotes()
        {
            throw new NotImplementedException();
        }
    }
}

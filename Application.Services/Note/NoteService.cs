using Application.Note;
using Common.Core.DependencyInjection;
using Core;
using Domain.Image;
using Domain.Note;
using Domain.Services.LoginToken;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services.Note
{
    [ServiceLocate(typeof(INoteService))]
    public class NoteService : INoteService
    {
        private readonly ILoginTokenGateway _loginTokenGateway;

        public NoteService(
            ILoginTokenGateway loginTokenGateway)
        {
            _loginTokenGateway = loginTokenGateway;
        }

        public void CreateComment(string loginToken, string noteId, CommentModel model)
        {
            throw new NotImplementedException();
        }

        public void CreateNote(string loginToken, NoteModel model)
        {
            var login = _loginTokenGateway.Get(loginToken);
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

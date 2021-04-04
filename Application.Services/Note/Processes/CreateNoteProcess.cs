using Application.Note;
using Common.Core.DependencyInjection;
using Core;
using Domain.Note;
using Domain.Services.LoginToken;
using Domain.Services.Note.Persistors;

namespace Application.Services.Note.Processes
{
    [ServiceLocate(typeof(ICreateNoteProcess))]
    public class CreateNoteProcess : ICreateNoteProcess
    {
        private readonly ILoginTokenGateway _loginTokenGateway;
        private readonly INotePersistor _notePersistor;

        public CreateNoteProcess(
            ILoginTokenGateway loginTokenGateway,
            INotePersistor notePersistor)
        {
            _loginTokenGateway = loginTokenGateway;
            _notePersistor = notePersistor;
        }

        public void Create(string loginToken, NoteModel model)
        {
            var login = _loginTokenGateway.Get(loginToken);

            var note = new NoteAspect
            {
                Content = model.Content,
                Title = model.Title,
                CreatedBy = login.OpenId,
                CreatedOn = DateTimeUtil.GetNow(),
                Reference = NoteReference.Create()
            };

            _notePersistor.Persist(new NoteDomain(note));
        }
    }
}

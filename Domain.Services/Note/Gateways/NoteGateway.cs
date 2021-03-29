using Common.Core.DependencyInjection;
using Domain.Note;
using System;

namespace Domain.Services.Note.Gateways
{
    [ServiceLocate(typeof(INoteGateway))]
    public class NoteGateway : INoteGateway
    {
        public INote Load(string noteId)
        {
            throw new NotImplementedException();
        }
    }
}

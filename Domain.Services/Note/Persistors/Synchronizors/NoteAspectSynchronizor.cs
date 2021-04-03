using Common.Core.Data.Sql;
using Common.Core.DependencyInjection;
using Domain.Note;
using Domain.Services.Note.Gateways.Loaders;
using Infrastructure.Data.Sql.Note.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Services.Note.Persistors.Synchronizors
{
    [ServiceLocate(typeof(INoteAspectSynchronizor))]
    public class NoteAspectSynchronizor : Persistor<INoteAspect, NoteEntity>, INoteAspectSynchronizor
    {
        private readonly INoteAspectLoader _noteAspectLoader;

        public NoteAspectSynchronizor(
            IUnitOfWork<NoteEntity> uow,
            INoteAspectLoader noteAspectLoader) : base(uow)
        {
            _noteAspectLoader = noteAspectLoader;
        }

        public void Synchronize(INoteAspect aspect)
        {
            throw new NotImplementedException();
        }

        protected override NoteEntity Map(INoteAspect aspect)
        {
            return new NoteEntity
            {
                content = aspect.Content,
                createdBy = aspect.CreatedBy.Code,
                createdOn = aspect.CreatedOn,
                noteId = aspect.Reference.Code,
                title = aspect.Title
            };
        }
    }
}

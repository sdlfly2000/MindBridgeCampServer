using Common.Core.Data.Sql;
using Common.Core.DependencyInjection;
using Domain.Note;
using Domain.Services.Note.Gateways.Loaders;
using Infrastructure.Data.Sql.Note.Entities;

namespace Domain.Services.Note.Persistors.Synchronizors
{
    [ServiceLocate(typeof(INoteAspectSynchronizor))]
    public class NoteAspectSynchronizor : Synchronizor<INoteAspect, NoteEntity>, INoteAspectSynchronizor
    {
        public NoteAspectSynchronizor(
            IUnitOfWork<NoteEntity> uow,
            INoteAspectLoader noteAspectLoader) : base(uow, noteAspectLoader)
        {
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

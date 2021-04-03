using Common.Core.Data.Sql;
using Common.Core.DependencyInjection;
using Domain.Note;
using Domain.Services.Note.Gateways.Loaders;
using Infrastructure.Data.Sql.Note.Entities;

namespace Domain.Services.Note.Persistors.Synchronizors
{
    [ServiceLocate(typeof(ITagAspectSynchronizor))]
    public class TagAspectSynchronizor : Synchronizor<ITagAspect, TagEntity>, ITagAspectSynchronizor
    {
        public TagAspectSynchronizor(
            IUnitOfWork<TagEntity> uow, 
            ITagAspectLoader tagAspectLoader) : base(uow, tagAspectLoader)
        {
        }

        protected override TagEntity Map(ITagAspect aspect)
        {
            return new TagEntity
            {
                caption = aspect.Caption,
                createdBy = aspect.CreatedBy.Code,
                createdOn = aspect.CreatedOn,
                noteId = aspect.Note.Code,
                tagId = aspect.Reference.Code
            };
        }
    }
}

using Common.Core.Data.Sql;
using Common.Core.DependencyInjection;
using Domain.Note;
using Domain.Services.Note.Gateways.Loaders;
using Infrastructure.Data.Sql.Note.Entities;

namespace Domain.Services.Note.Persistors.Synchronizors
{
    [ServiceLocate(typeof(IViewerAspectSynchronizor))]
    public class ViewerAspectSynchronizor : Synchronizor<IViewerAspect, ViewerEntity>, IViewerAspectSynchronizor
    {
        public ViewerAspectSynchronizor(
            IUnitOfWork<ViewerEntity> uow, 
            IViewerAspectLoader aspectLoader) : base(uow, aspectLoader)
        {
        }

        protected override ViewerEntity Map(IViewerAspect aspect)
        {
            return new ViewerEntity
            {
                createdBy = aspect.CreatedBy.Code,
                createdOn = aspect.CreatedOn,
                noteId = aspect.Note.Code,
                viewerId = aspect.Reference.Code
            };
        }
    }
}

using Common.Core.DependencyInjection;
using Domain.Note;
using Domain.User;
using Infrastructure.Data.Sql.Note.Entities;

namespace Domain.Services.Note.Gateways.Loaders.Mappers
{
    [ServiceLocate(typeof(IViewerAspectMapper))]
    public class ViewerAspectMapper : IViewerAspectMapper
    {
        public IViewerAspect Map(ViewerEntity entity)
        {
            return new ViewerAspect
            {
                CreatedBy = new UserReference(entity.createdBy),
                CreatedOn = entity.createdOn,
                Note = new NoteReference(entity.noteId),
                Reference = new ViewerReference(entity.viewerId)
            };
        }
    }
}

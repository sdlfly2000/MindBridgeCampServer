using Domain.Note;
using Infrastructure.Data.Sql.Note.Entities;

namespace Domain.Services.Note.Gateways.Loaders.Mappers
{
    public interface IViewerAspectMapper
    {
        IViewerAspect Map(ViewerEntity entity);
    }
}

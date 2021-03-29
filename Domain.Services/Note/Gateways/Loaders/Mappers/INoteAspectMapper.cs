using Domain.Note;
using Infrastructure.Data.Sql.Note.Entities;

namespace Domain.Services.Note.Gateways.Loaders.Mappers
{
    public interface INoteAspectMapper
    {
        INoteAspect Map(NoteEntity entity);
    }
}

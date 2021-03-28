using Infrastructure.Data.Sql.Note.Entities;

namespace Infrastructure.Data.Sql.Note.Repositories
{
    public interface INoteRepository
    {
        NoteEntity FindById(string id);
    }
}

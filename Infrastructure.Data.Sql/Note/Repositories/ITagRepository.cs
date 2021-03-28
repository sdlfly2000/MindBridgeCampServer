using Infrastructure.Data.Sql.Note.Entities;
using System.Collections.Generic;

namespace Infrastructure.Data.Sql.Note.Repositories
{
    public interface ITagRepository
    {
        TagEntity FindById(string id);

        IList<TagEntity> FindByNote(string noteId);
    }
}

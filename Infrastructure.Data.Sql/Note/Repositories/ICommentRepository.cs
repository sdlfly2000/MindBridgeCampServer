using Infrastructure.Data.Sql.Note.Entities;
using System.Collections.Generic;

namespace Infrastructure.Data.Sql.Note.Repositories
{
    public interface ICommentRepository
    {
        CommentEntity FindById(string id);

        IList<CommentEntity> FindByNote(string noteId);
    }
}

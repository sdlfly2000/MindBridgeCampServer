using Common.Core.DependencyInjection;
using Infrastructure.Data.Sql.Note.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Data.Sql.Note.Repositories
{
    [ServiceLocate(typeof(ICommentRepository))]
    public class CommentRepository : ICommentRepository
    {
        private readonly IMindBridgeCampDbContext _context;

        public CommentRepository(IMindBridgeCampDbContext context)
        {
            _context = context;
        }

        public CommentEntity FindById(string id)
        {
            return FindAll().FirstOrDefault(Comment => Comment.commentId.Equals(id));
        }

        public IList<CommentEntity> FindByNote(string noteId)
        {
            return FindAll().Where(comment => comment.noteId.Equals(noteId)).ToList();
        }

        private IQueryable<CommentEntity> FindAll()
        {
            return _context.NoteComments.AsQueryable();
        }
    }
}

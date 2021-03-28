using Common.Core.DependencyInjection;
using Infrastructure.Data.Sql.Note.Entities;
using System.Linq;

namespace Infrastructure.Data.Sql.Note.Repositories
{
    [ServiceLocate(typeof(INoteRepository))]
    public class NoteRepository : INoteRepository
    {
        private readonly IMindBridgeCampDbContext _context;

        public NoteRepository(IMindBridgeCampDbContext context)
        {
            _context = context;
        }

        public NoteEntity FindById(string id)
        {
            return FindAll().FirstOrDefault(note => note.noteId.Equals(id));
        }

        private IQueryable<NoteEntity> FindAll()
        {
            return _context.Notes.AsQueryable();
        }
    }
}

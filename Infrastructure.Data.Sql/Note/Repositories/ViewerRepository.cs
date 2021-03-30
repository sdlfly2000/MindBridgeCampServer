using Common.Core.DependencyInjection;
using Infrastructure.Data.Sql.Note.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Data.Sql.Note.Repositories
{
    [ServiceLocate(typeof(IViewerRepository))]
    public class ViewerRepository : IViewerRepository
    {
        private readonly IMindBridgeCampDbContext _context;

        public ViewerRepository(IMindBridgeCampDbContext context)
        {
            _context = context;
        }

        public ViewerEntity FindById(string id)
        {
            return FindAll().FirstOrDefault(viewer => viewer.noteId.Equals(id));
        }

        public IList<ViewerEntity> FindByNote(string noteId)
        {
            return FindAll().Where(viewer => viewer.noteId.Equals(noteId)).ToList();
        }

        private IQueryable<ViewerEntity> FindAll()
        {
            return _context.NoteViewers.AsQueryable();
        }
    }
}

using Common.Core.DependencyInjection;
using Infrastructure.Data.Sql.Note.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Data.Sql.Note.Repositories
{
    [ServiceLocate(typeof(ITagRepository))]
    public class TagRepository : ITagRepository
    {
        private readonly IMindBridgeCampDbContext _context;

        public TagRepository(IMindBridgeCampDbContext context)
        {
            _context = context;
        }

        public TagEntity FindById(string id)
        {
            return FindAll().FirstOrDefault(tag => tag.noteId.Equals(id));
        }

        public IList<TagEntity> FindByNote(string noteId)
        {
            return FindAll().Where(tag => tag.noteId.Equals(noteId)).ToList();
        }

        private IQueryable<TagEntity> FindAll()
        {
            return _context.NoteTags.AsQueryable();
        }
    }
}

using Common.Core.AOP;
using Common.Core.DependencyInjection;
using Domain.Note;
using Domain.Services.Note.Gateways.Loaders.Mappers;
using Infrastructure.Data.Sql.Note.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Services.Note.Gateways.Loaders
{
    [ServiceLocate(typeof(ITagAspectLoader))]
    public class TagAspectLoader : ITagAspectLoader
    {
        private readonly ITagRepository _tagRepository;
        private readonly ITagAspectMapper _tagAspectMapper;

        public TagAspectLoader(
            ITagRepository tagRepository,
            ITagAspectMapper tagAspectMapper)
        {
            _tagRepository = tagRepository;
            _tagAspectMapper = tagAspectMapper;
        }

        public ITagAspect Load(IReference reference)
        {
            return _tagAspectMapper.Map(_tagRepository.FindById(reference.Code));
        }

        public IList<ITagAspect> LoadByNote(NoteReference note)
        {
            return _tagRepository
                .FindByNote(note.Code)
                .Select(_tagAspectMapper.Map)
                .ToList();
        }
    }
}

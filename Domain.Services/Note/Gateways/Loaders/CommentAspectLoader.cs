using Common.Core.AOP;
using Common.Core.DependencyInjection;
using Domain.Note;
using Domain.Services.Note.Gateways.Loaders.Mappers;
using Infrastructure.Data.Sql.Note.Repositories;
using System.Collections.Generic;
using System.Linq;
using Core;

namespace Domain.Services.Note.Gateways.Loaders
{
    [ServiceLocate(typeof(ICommentAspectLoader))]
    [AspectCache("class")]
    public class CommentAspectLoader : ICommentAspectLoader
    {
        private readonly ICommentRepository _commentRepository;
        private readonly ICommentAspectMapper _commentAspectMapper;

        public CommentAspectLoader(
            ICommentRepository commentRepository,
            ICommentAspectMapper commentAspectMapper)
        {
            _commentRepository = commentRepository;
            _commentAspectMapper = commentAspectMapper;
        }

        [AspectCache("Load")]
        public ICommentAspect Load(IReference reference)
        {
            return _commentAspectMapper.Map(_commentRepository.FindById(reference.Code));
        }

        [AspectCache("LoadByNote")]
        public IList<ICommentAspect> LoadByNote(NoteReference note)
        {
            return _commentRepository
                .FindByNote(note.Code)
                .Select(_commentAspectMapper.Map)
                .ToList();
        }
    }
}

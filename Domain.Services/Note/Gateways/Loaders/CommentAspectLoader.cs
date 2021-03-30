using Common.Core.DependencyInjection;
using Domain.Note;
using Domain.Services.Note.Gateways.Loaders.Mappers;
using Infrastructure.Data.Sql.Note.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Services.Note.Gateways.Loaders
{
    [ServiceLocate(typeof(ICommentAspectLoader))]
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

        public ICommentAspect Load(CommentReference comment)
        {
            return _commentAspectMapper.Map(_commentRepository.FindById(comment.Code));
        }

        public IList<ICommentAspect> LoadByNote(NoteReference note)
        {
            return _commentRepository
                .FindByNote(note.Code)
                .Select(_commentAspectMapper.Map)
                .ToList();
        }
    }
}

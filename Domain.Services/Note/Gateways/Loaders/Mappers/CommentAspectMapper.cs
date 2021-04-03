using Common.Core.DependencyInjection;
using Domain.Note;
using Domain.User;
using Infrastructure.Data.Sql.Note.Entities;

namespace Domain.Services.Note.Gateways.Loaders.Mappers
{
    [ServiceLocate(typeof(ICommentAspectMapper))]
    public class CommentAspectMapper : ICommentAspectMapper
    {
        public ICommentAspect Map(CommentEntity entity)
        {
            return entity != null
                ? new CommentAspect
                    {
                        Reference = new CommentReference(entity.commentId),
                        Content = entity.content,
                        CreatedBy = new UserReference(entity.createdBy),
                        CreatedOn = entity.createdOn,
                        Note = new NoteReference(entity.noteId),
                        Rate = entity.rate
                    }
                : default(ICommentAspect);
        }
    }
}

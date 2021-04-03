using Common.Core.Data.Sql;
using Common.Core.DependencyInjection;
using Domain.Note;
using Domain.Services.Note.Gateways.Loaders;
using Infrastructure.Data.Sql.Note.Entities;

namespace Domain.Services.Note.Persistors.Synchronizors
{
    [ServiceLocate(typeof(ICommentAspectSynchronizor))]
    public class CommentAspectSynchronizor : Persistor<ICommentAspect, CommentEntity>, ICommentAspectSynchronizor
    {
        private readonly ICommentAspectLoader _commentAspectLoader;

        public CommentAspectSynchronizor(
            IUnitOfWork<CommentEntity> uow,
            ICommentAspectLoader commentAspectLoader)
            : base(uow)
        {
            _commentAspectLoader = commentAspectLoader;
        }

        public void Synchronize(ICommentAspect aspect)
        {
            var commentAspect = _commentAspectLoader.Load(aspect.Reference);

            if (commentAspect == default(ICommentAspect))
            {
                Add(aspect);
            };

            Update(aspect);
        }

        protected override CommentEntity Map(ICommentAspect aspect)
        {
            return new CommentEntity
            {
                commentId = aspect.Reference.Code,
                content = aspect.Content,
                createdBy = aspect.CreatedBy.Code,
                createdOn = aspect.CreatedOn,
                noteId = aspect.Note.Code,
                rate = aspect.Rate
            };
        }
    }
}

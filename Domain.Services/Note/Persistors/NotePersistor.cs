using Common.Core.Data.Sql;
using Common.Core.DependencyInjection;
using Domain.Note;
using Domain.Services.Note.Persistors.Synchronizors;
using System.Collections.Generic;

namespace Domain.Services.Note.Persistors
{
    [ServiceLocate(typeof(INotePersistor))]
    public class NotePersistor : INotePersistor
    {
        private readonly IPersistence _persistence;
        private readonly INoteAspectSynchronizor _noteAspectSynchronizor;
        private readonly ICommentAspectSynchronizor _commentAspectSynchronizor;
        private readonly IViewerAspectSynchronizor _viewerAspectSynchronizor;
        private readonly ITagAspectSynchronizor _tagAspectSynchronizor;

        public NotePersistor(
            IPersistence persistence,
            INoteAspectSynchronizor noteAspectSynchronizor,
            ICommentAspectSynchronizor commentAspectSynchronizor,
            IViewerAspectSynchronizor viewerAspectSynchronizor,
            ITagAspectSynchronizor tagAspectSynchronizor)
        {
            _persistence = persistence;
            _noteAspectSynchronizor = noteAspectSynchronizor;
            _commentAspectSynchronizor = commentAspectSynchronizor;
            _viewerAspectSynchronizor = viewerAspectSynchronizor;
            _tagAspectSynchronizor = tagAspectSynchronizor;
        }

        public void Persist(INote note)
        {
            _noteAspectSynchronizor.Synchronize(note);

            var comments = note.Comments as List<CommentAspect>;
            var viewers = note.Viewers as List<ViewerAspect>;
            var tags = note.Tags as List<TagAspect>;

            comments.ForEach(comment => _commentAspectSynchronizor.Synchronize(comment));
            viewers.ForEach(viewer => _viewerAspectSynchronizor.Synchronize(viewer));
            tags.ForEach(tag => _tagAspectSynchronizor.Synchronize(tag));

            _persistence.Complete();
        }
    }
}

using Common.Core.DependencyInjection;
using Domain.Note;
using Domain.Services.Note.Gateways.Loaders;

namespace Domain.Services.Note.Gateways
{
    [ServiceLocate(typeof(INoteGateway))]
    public class NoteGateway : INoteGateway
    {
        private readonly INoteAspectLoader _noteAspectLoader;
        private readonly ICommentAspectLoader _commentAspectLoader;
        private readonly IViewerAspectLoader _viewerAspectLoader;
        private readonly ITagAspectLoader _tagAspectLoader;


        public NoteGateway(
            INoteAspectLoader noteAspectLoader,
            ICommentAspectLoader commentAspectLoader,
            IViewerAspectLoader viewerAspectLoader,
            ITagAspectLoader tagAspectLoader)
        {
            _noteAspectLoader = noteAspectLoader;
            _commentAspectLoader = commentAspectLoader;
            _viewerAspectLoader = viewerAspectLoader;
            _tagAspectLoader = tagAspectLoader;
        }

        public INote Load(string noteId)
        {
            var noteReference = new NoteReference(noteId);
            var noteAspect = _noteAspectLoader.Load(noteReference);
            return new NoteDomain(noteAspect)
            {
                Tags = _tagAspectLoader.LoadByNote(noteReference),
                Comments = _commentAspectLoader.LoadByNote(noteReference),
                Viewers = _viewerAspectLoader.LoadByNote(noteReference)
            };
        }
    }
}

using System.Collections.Generic;

namespace Domain.Note
{
    public interface INote : INoteAspect
    {
        IList<ICommentAspect> Comments { get; set; }
        IList<IViewerAspect> Viewers { get; set; }
        IList<ITagAspect> Tags { get; set; }
    }
}

using Domain.Image;
using Domain.User;
using System;
using System.Collections.Generic;

namespace Domain.Note
{
    public interface INoteAspect
    {
        NoteReference Reference { get; set; }
        UserReference CreatedBy { get; set; }
        DateTime CreatedOn { get; set; }
        string Content { get; set; }
        string Title { get; set; }
        IList<ImageReference> Images { get; set; }
    }
}

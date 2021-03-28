using Domain.Image;
using Domain.User;
using System;

namespace Domain.Note
{
    public interface INoteAspect
    {
        NoteReference Reference { get; set; }
        UserReference CreatedBy { get; set; }
        DateTime CreatedOn { get; set; }
        string Content { get; set; }
        string Title { get; set; }
        ImageReference Image { get; set; }
    }
}

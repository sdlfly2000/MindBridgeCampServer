using Domain.Image;
using Domain.User;
using System;

namespace Domain.Note
{
    public class NoteAspect : INoteAspect
    {
        public NoteReference Reference { get; set; }
        public UserReference CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }
        public ImageReference Image { get; set; }
    }
}

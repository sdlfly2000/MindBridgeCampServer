using Domain.User;
using System;

namespace Domain.Note
{
    public class ViewerAspect : IViewerAspect
    {
        public ViewerReference Reference { get; set; }
        public NoteReference Note { get; set; }
        public DateTime CreatedOn { get; set; }
        public UserReference CreatedBy { get; set; }
    }
}

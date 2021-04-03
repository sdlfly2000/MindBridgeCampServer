using Common.Core.AOP;
using Domain.User;
using System;

namespace Domain.Note
{
    public class ViewerAspect : IViewerAspect
    {
        public NoteReference Note { get; set; }
        public DateTime CreatedOn { get; set; }
        public UserReference CreatedBy { get; set; }
        public IReference Reference { get; set; }
    }
}

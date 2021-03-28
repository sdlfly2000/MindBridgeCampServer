using Domain.User;
using System;

namespace Domain.Note
{
    public class TagAspect : ITagAspect
    {
        public TagReference Reference { get; set; }
        public NoteReference Note { get; set; }
        public DateTime CreatedOn { get; set; }
        public UserReference CreatedBy { get; set; }
        public string Caption { get; set; }
    }
}

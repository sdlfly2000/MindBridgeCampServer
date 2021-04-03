using Common.Core.AOP;
using Domain.Image;
using Domain.User;
using System;
using System.Collections.Generic;

namespace Domain.Note
{
    public class NoteAspect : INoteAspect
    {
        public NoteAspect()
        {
            Images = new List<ImageReference>();
        }

        public IReference Reference { get; set; }
        public UserReference CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }
        public IList<ImageReference> Images { get; set; }
    }
}

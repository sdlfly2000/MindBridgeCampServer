using Domain.Image;
using Domain.User;
using System;
using System.Collections.Generic;

namespace Domain.Note
{
    public class Note : INote
    {
        private readonly INoteAspect _noteAspect;

        public Note(INoteAspect noteAspect)
        {
            _noteAspect = noteAspect;
            Comments = new List<ICommentAspect>();
            Viewers = new List<IViewerAspect>();
            Tags = new List<ITagAspect>();
        }

        public IList<ICommentAspect> Comments { get; set; }
        public IList<IViewerAspect> Viewers { get; set; }
        public IList<ITagAspect> Tags { get; set; }
        public NoteReference Reference { get => _noteAspect.Reference; set => _noteAspect.Reference = value; }
        public UserReference CreatedBy { get => _noteAspect.CreatedBy; set => _noteAspect.CreatedBy = value; }
        public DateTime CreatedOn { get => _noteAspect.CreatedOn; set => _noteAspect.CreatedOn = value; }
        public string Content { get => _noteAspect.Content; set => _noteAspect.Content = value; }
        public string Title { get => _noteAspect.Title; set => _noteAspect.Title = value; }
        public ImageReference Image { get => _noteAspect.Image; set => _noteAspect.Image = value; }
    }
}

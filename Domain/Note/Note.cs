using Common.Core.AOP;
using Domain.Image;
using Domain.User;
using System;
using System.Collections.Generic;

namespace Domain.Note
{
    public class NoteDomain : INote
    {
        private readonly INoteAspect _noteAspect;

        public NoteDomain(INoteAspect noteAspect)
        {
            _noteAspect = noteAspect;
            Comments = new List<ICommentAspect>();
            Viewers = new List<IViewerAspect>();
            Tags = new List<ITagAspect>();
        }

        public IList<ICommentAspect> Comments { get; set; }
        public IList<IViewerAspect> Viewers { get; set; }
        public IList<ITagAspect> Tags { get; set; }
        public IReference Reference { get => _noteAspect.Reference; set => _noteAspect.Reference = value; }
        public UserReference CreatedBy { get => _noteAspect.CreatedBy; set => _noteAspect.CreatedBy = value; }
        public DateTime CreatedOn { get => _noteAspect.CreatedOn; set => _noteAspect.CreatedOn = value; }
        public string Content { get => _noteAspect.Content; set => _noteAspect.Content = value; }
        public string Title { get => _noteAspect.Title; set => _noteAspect.Title = value; }
        public IList<ImageReference> Images { get => _noteAspect.Images; set => _noteAspect.Images = value; }
    }
}

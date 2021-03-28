using Domain.User;
using System;

namespace Domain.Note
{
    public interface ICommentAspect
    {
        CommentReference Referece { get; set; }
        NoteReference Note { get; set; }
        DateTime CreatedOn { get; set; }
        UserReference CreatedBy { get; set; }
        string Content { get; set; }
        int Rate { get; set; }
    }
}

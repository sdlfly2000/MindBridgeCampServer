﻿using Common.Core.AOP;
using Domain.User;
using System;

namespace Domain.Note
{
    public class CommentAspect : ICommentAspect
    {
        public IReference Reference { get; set; }
        public NoteReference Note { get; set; }
        public DateTime CreatedOn { get; set; }
        public UserReference CreatedBy { get; set; }
        public string Content { get; set; }
        public int Rate { get; set; }
    }
}

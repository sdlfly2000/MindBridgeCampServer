using Common.Core.Domain;
using Domain.User;
using System;

namespace Domain.Note
{
    public interface ITagAspect : IAspect
    {
        NoteReference Note { get; set; }
        DateTime CreatedOn { get; set; }
        UserReference CreatedBy { get; set; }
        string Caption { get; set; }
    }
}

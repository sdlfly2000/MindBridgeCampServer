using Common.Core.Domain;
using Domain.User;
using System;

namespace Domain.Image
{
    public interface IImageAspect : IAspect
    {
        string ImageName { get;}
        string Extention { get; set; }
        UserReference CreatedBy { get; set; }
        DateTime CreatedOn { get; set; }
        ImageStatus Status { get; set; }
    }
}

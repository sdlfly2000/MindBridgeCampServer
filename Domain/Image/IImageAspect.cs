using Domain.User;
using System;

namespace Domain.Image
{
    public interface IImageAspect
    {
        ImageReference Reference { get; set; }
        string ImageName { get;}
        string Extention { get; set; }
        UserReference CreatedBy { get; set; }
        DateTime CreatedOn { get; set; }
        ImageStatus Status { get; set; }
    }
}

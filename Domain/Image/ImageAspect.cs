using Domain.User;
using System;

namespace Domain.Image
{
    public class ImageAspect : IImageAspect
    {
        public ImageReference Reference { get; set; }
        public string ImageName { get => string.Format("{0}.{1}", Reference.Code, Extention);}
        public string Extention { get; set; }
        public UserReference CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public ImageStatus Status { get; set; }
    }
}

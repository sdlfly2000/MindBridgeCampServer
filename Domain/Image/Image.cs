using Domain.User;
using System;

namespace Domain.Image
{
    public class Image : IImage
    {
        private readonly IImageAspect _imageAspect;

        public Image(IImageAspect imageAspet)
        {
            _imageAspect = imageAspet;
        }

        public ImageReference Reference
        {
            get { return _imageAspect.Reference; }
            set { _imageAspect.Reference = value; }
        }

        public string ImageName
        {
            get { return _imageAspect.ImageName; }
        }

        public string Extention
        {
            get { return _imageAspect.Extention; }
            set { _imageAspect.Extention = value; }
        }

        public UserReference CreatedBy
        {
            get { return _imageAspect.CreatedBy; }
            set { _imageAspect.CreatedBy = value; }
        }

        public DateTime CreatedOn
        {
            get { return _imageAspect.CreatedOn; }
            set { _imageAspect.CreatedOn = value; }
        }

        public ImageStatus Status
        {
            get { return _imageAspect.Status; }
            set { _imageAspect.Status = value; }
        }
    }
}

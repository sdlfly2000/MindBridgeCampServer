using Common.Core.AOP;
using Domain.User;
using System;
using System.IO;

namespace Domain.Image
{
    public class Image : IImage
    {
        private readonly IImageAspect _imageAspect;
        private readonly IImageStreamAspect _streamAspect;

        public Image(IImageAspect imageAspet, IImageStreamAspect streamAspect)
        {
            _imageAspect = imageAspet;
            _streamAspect = streamAspect;
        }

        public IReference Reference
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

        public Stream ImageStream
        {
            get { return _streamAspect.ImageStream; }
            set { _streamAspect.ImageStream = value; }
        }
    }
}

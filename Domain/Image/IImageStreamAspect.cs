using System.IO;

namespace Domain.Image
{
    public interface IImageStreamAspect
    {
        Stream ImageStream { get; set; }
    }
}

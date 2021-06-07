using Infrastructure.Data.Sql.Image.Entities;
using System.IO;

namespace Infrastructure.File.Image
{
    public class ImageSaveRequest
    {
        public ImageEntity Entity { get; set; }
        public Stream ImageStream { get; set; }
    }
}

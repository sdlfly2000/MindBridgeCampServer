using Common.Core.DependencyInjection;
using Microsoft.Extensions.Configuration;
using SysFile = System.IO.File;

namespace Infrastructure.File.Image
{
    [ServiceLocate(typeof(IImageStorage))]
    public class ImageStorage : IImageStorage
    {
        private readonly string _storePath;

        public ImageStorage(IConfiguration config)
        {
            _storePath = config["ImagePath"];
        }

        public void Save(ImageSaveRequest request)
        {
            var fileNamePath = _storePath + request.Entity.imageId + "." + request.Entity.extension;

            using (var file = SysFile.Create(fileNamePath))
            {
                request.ImageStream.CopyTo(file);
                file.Close();
                request.ImageStream.Close();
            }
        }
    }
}

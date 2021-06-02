using Common.Core.DependencyInjection;
using Domain.Image;
using Domain.Services.Image.Gateways.Loaders.Mappers;
using Infrastructure.Data.Sql.Image.Repositories;

namespace Domain.Services.Image.Gateways.Loaders
{
    [ServiceLocate(typeof(IImageAspectLoader))]
    public class ImageAspectLoader : IImageAspectLoader
    {
        private readonly IImageRepository _imageRepository;
        private readonly IImageAspectMapper _imageAspectMapper;

        public ImageAspectLoader(
            IImageRepository imageRepository,
            IImageAspectMapper imageAspectMapper)
        {
            _imageRepository = imageRepository;
            _imageAspectMapper = imageAspectMapper;
        }

        public IImageAspect Load(ImageReference refernce)
        {
            return _imageAspectMapper.Map(_imageRepository.FindById(refernce.Code));
        }
    }
}

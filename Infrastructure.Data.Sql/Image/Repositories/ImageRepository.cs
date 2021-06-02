using Common.Core.DependencyInjection;
using Infrastructure.Data.Sql.Image.Entities;
using System.Linq;

namespace Infrastructure.Data.Sql.Image.Repositories
{
    [ServiceLocate(typeof(IImageRepository))]
    public class ImageRepository : IImageRepository
    {
        private readonly IMindBridgeCampDbContext _context;

        public ImageRepository(IMindBridgeCampDbContext context)
        {
            _context = context;
        }

        public ImageEntity FindById(string id)
        {
            return FindAll().FirstOrDefault(image => image.imageId.Equals(id));
        }

        private IQueryable<ImageEntity> FindAll()
        {
            return _context.Images.AsQueryable();
        }
    }
}

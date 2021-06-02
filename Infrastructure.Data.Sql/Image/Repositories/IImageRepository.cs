using Infrastructure.Data.Sql.Image.Entities;

namespace Infrastructure.Data.Sql.Image.Repositories
{
    public interface IImageRepository
    {
        ImageEntity FindById(string id);
    }
}

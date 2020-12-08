using Common.Core.DependencyInjection;
using Infrastructure.Data.Sql.User.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Sql
{
    [ServiceLocate(typeof(IMindBridgeCampDbContext))]
    public class MindBridgeCampDbContext : DbContext, IMindBridgeCampDbContext
    {
        public MindBridgeCampDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<UserEntity> Users { get; set; }
    }
}
using Infrastructure.Data.Sql.User.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Sql
{
    public interface IMindBridgeCampDbContext
    {
        DbSet<UserEntity> Users { get; set; }

        DbSet<UserInfoEntity> UserInfos { get; set; }
    }
}

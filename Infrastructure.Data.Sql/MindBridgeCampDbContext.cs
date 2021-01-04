using Common.Core.DependencyInjection;
using Infrastructure.Data.Sql.LearningRoom.Entities;
using Infrastructure.Data.Sql.User.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Infrastructure.Data.Sql
{
    [ServiceLocate(typeof(IMindBridgeCampDbContext), ServiceType.Scoped)]
    public class MindBridgeCampDbContext : DbContext, IMindBridgeCampDbContext
    {
        public MindBridgeCampDbContext(DbContextOptions options) : base(options)
        {

        }        

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<UserInfoEntity> UserInfos { get; set; }
        public DbSet<RoomEntity> Rooms { get; set; }
        public DbSet<SignInEntity> SignIns { get; set; }
        public DbSet<ChatEntity> Chats { get; set; }
        public DbSet<ParticipantEntity> Participants { get; set; }

        public DbSet<TEntity> Get<TEntity>() where TEntity : class
        {
            return Set<TEntity>();
        }

        public EntityEntry<TEntity> GetEntry<TEntity>(TEntity entity) where TEntity : class
        {
            return Entry<TEntity>(entity);
        }

        public void Save()
        {
            SaveChanges();
        }
    }
}
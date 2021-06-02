using Common.Core.DependencyInjection;
using Infrastructure.Data.Sql.Image.Entities;
using Infrastructure.Data.Sql.LearningRoom.Entities;
using Infrastructure.Data.Sql.Note.Entities;
using Infrastructure.Data.Sql.User.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Threading.Tasks;

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
        public DbSet<CommentEntity> NoteComments { get; set; }
        public DbSet<NoteEntity> Notes { get; set; }
        public DbSet<TagEntity> NoteTags { get; set; }
        public DbSet<ViewerEntity> NoteViewers { get; set; }
        public DbSet<ImageEntity> Images { get; set; }

        public DbSet<TEntity> Get<TEntity>() where TEntity : class
        {
            return Set<TEntity>();
        }

        public EntityEntry<TEntity> GetEntry<TEntity>(TEntity entity) where TEntity : class
        {
            return Entry<TEntity>(entity);
        }

        public async Task<int> Save()
        {
            return await SaveChangesAsync();
        }
    }
}
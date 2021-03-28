using Infrastructure.Data.Sql.LearningRoom.Entities;
using Infrastructure.Data.Sql.Note.Entities;
using Infrastructure.Data.Sql.User.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Threading.Tasks;

namespace Infrastructure.Data.Sql
{
    public interface IMindBridgeCampDbContext
    {
        DbSet<UserEntity> Users { get; set; }

        DbSet<UserInfoEntity> UserInfos { get; set; }

        DbSet<RoomEntity> Rooms { get; set; }

        DbSet<SignInEntity> SignIns { get; set; }

        DbSet<ChatEntity> Chats { get; set; }

        DbSet<ParticipantEntity> Participants { get; set; }

        DbSet<CommentEntity> NoteComments { get; set; }

        DbSet<NoteEntity> Notes { get; set; }

        DbSet<TagEntity> NoteTags { get; set; }

        DbSet<ViewerEntity> NoteViewers { get; set; } 

        DbSet<TEntity> Get<TEntity>() where TEntity : class;

        EntityEntry<TEntity> GetEntry<TEntity>(TEntity entity) where TEntity: class;

        Task<int> Save();
    }
}

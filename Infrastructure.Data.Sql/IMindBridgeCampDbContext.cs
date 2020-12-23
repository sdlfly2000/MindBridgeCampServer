using Infrastructure.Data.Sql.LearningRoom.Entities;
using Infrastructure.Data.Sql.User.Entities;
using Microsoft.EntityFrameworkCore;

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

        DbSet<TEntity> Get<TEntity>() where TEntity : class;

        void Save();
    }
}

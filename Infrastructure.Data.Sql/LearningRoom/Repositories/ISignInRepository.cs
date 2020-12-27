using Infrastructure.Data.Sql.LearningRoom.Entities;
using System.Collections.Generic;

namespace Infrastructure.Data.Sql.LearningRoom.Repositories
{
    public interface ISignInRepository
    {
        SignInEntity FindById(string id);

        IList<SignInEntity> FindByRoom(string roomId);
    }
}

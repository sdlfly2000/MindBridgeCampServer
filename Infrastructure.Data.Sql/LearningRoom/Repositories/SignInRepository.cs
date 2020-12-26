using Common.Core.DependencyInjection;
using Infrastructure.Data.Sql.LearningRoom.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Data.Sql.LearningRoom.Repositories
{
    [ServiceLocate(typeof(ISignInRepository))]
    public class SignInRepository : ISignInRepository
    {
        private readonly IMindBridgeCampDbContext _context;

        public SignInRepository(IMindBridgeCampDbContext context)
        {
            _context = context;
        }

        SignInEntity ISignInRepository.FindById(string id)
        {
            return FindAll().FirstOrDefault(s => s.signInId.Equals(id));
        }

        IList<SignInEntity> ISignInRepository.FindByRomm(string roomId)
        {
            return FindAll().Where(s => s.roomId.Equals(roomId)).ToList();
        }

        private IQueryable<SignInEntity> FindAll()
        {
            return _context.SignIns.AsQueryable();
        }
    }
}

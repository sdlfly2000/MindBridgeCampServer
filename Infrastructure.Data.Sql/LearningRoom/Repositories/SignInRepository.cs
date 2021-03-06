﻿using Common.Core.DependencyInjection;
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

        public SignInEntity FindById(string id)
        {
            return FindAll().FirstOrDefault(s => s.signInId.Equals(id));
        }

        public IList<SignInEntity> FindByRoom(string roomId)
        {
            return FindAll().Where(s => s.roomId.Equals(roomId)).ToList();
        }

        public IList<SignInEntity> FindByUser(string userId)
        {
            return FindAll().Where(s => s.participant.Equals(userId)).ToList();
        }

        private IQueryable<SignInEntity> FindAll()
        {
            return _context.SignIns.AsQueryable();
        }
    }
}

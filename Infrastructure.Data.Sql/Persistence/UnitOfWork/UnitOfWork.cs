using Common.Core.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Sql.Persistence.UnitOfWork
{
    [ServiceLocate(typeof(IUnitOfWork<>))]
    public class UnitOfWork<TEntity> : IUnitOfWork<TEntity> where TEntity : class
    {
        private readonly IMindBridgeCampDbContext _context;

        public UnitOfWork(IMindBridgeCampDbContext context)
        {
            _context = context;
        }

        public void Add<TEntity>(TEntity entity) where TEntity : class
        {
            _context.Get<TEntity>().Add(entity);
        }

        public void Persist<TEntity>(TEntity entity) where TEntity : class
        {
            var entityEntry = _context.GetEntry<TEntity>(entity);
            switch (entityEntry.State)
            {
                case EntityState.Modified:
                    _context.Get<TEntity>().Update(entity);
                    break;
                case EntityState.Detached:
                    _context.Get<TEntity>().Attach(entity);
                    break;
            }
        }
    }
}

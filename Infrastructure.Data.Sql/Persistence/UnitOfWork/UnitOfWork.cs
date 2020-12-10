using Common.Core.DependencyInjection;

namespace Infrastructure.Data.Sql.Persistence.UnitOfWork
{
    [ServiceLocate(typeof(IUnitOfWork<IEntity>))]
    public class UnitOfWork<TEntity> : IUnitOfWork<TEntity> where TEntity : class
    {
        private readonly IMindBridgeCampDbContext _context;

        public UnitOfWork(IMindBridgeCampDbContext context)
        {
            _context = context;
        }

        public void Persist<TEntity>(TEntity entity) where TEntity : class
        {
            _context.Get<TEntity>().Update(entity);
        }
    }
}

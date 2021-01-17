using Common.Core.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Linq;

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
            var properties = entity.GetType().GetProperties()
                .FirstOrDefault(p => p.CustomAttributes.Any(a => a.AttributeType.Equals(typeof(KeyAttribute))));

            var id = properties.GetGetMethod().Invoke(entity, null);

            var entityExist = _context.Get<TEntity>().Find(id);

            _context.Get<TEntity>().Remove(entityExist);
            _context.Get<TEntity>().Add(entity);
        }
    }
}

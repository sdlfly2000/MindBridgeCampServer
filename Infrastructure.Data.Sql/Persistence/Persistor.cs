using System;
using Infrastructure.Data.Sql.Persistence.UnitOfWork;

namespace Infrastructure.Data.Sql.Persistence
{
    public abstract class Persistor<TAspect, TEntity> : IPersistor<TAspect> 
        where TAspect : class 
        where TEntity : class
    {
        private readonly IUnitOfWork<TEntity> _uow;

        public Persistor(IUnitOfWork<TEntity> uow)
        {
            _uow = uow;
        }

        public void Add(TAspect aspect)
        {
            _uow.Add(Map(aspect));
        }

        public void Update(TAspect aspect)
        {
            _uow.Persist(Map(aspect));
        }

        protected virtual TEntity Map(TAspect aspect)
        {
            throw new NotImplementedException();
        }
    }
}

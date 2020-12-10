namespace Infrastructure.Data.Sql.Persistence.UnitOfWork
{
    public interface IUnitOfWork<in TEntity> where TEntity : class
    {
        void Persist<TEntity>(TEntity entity) where TEntity : class;
    }
}

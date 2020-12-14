namespace Infrastructure.Data.CacheAgent
{
    public interface ICacheAgent<in TEntity> where TEntity : class
    {
        TEntity Get<TEntity>(string key) where TEntity : class;
    }
}

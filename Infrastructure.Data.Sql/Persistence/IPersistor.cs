namespace Infrastructure.Data.Sql.Persistence
{
    public interface IPersistor<in TAspect> where TAspect : class
    {
        void Add(TAspect aspect);

        void Update(TAspect aspect);
    }
}

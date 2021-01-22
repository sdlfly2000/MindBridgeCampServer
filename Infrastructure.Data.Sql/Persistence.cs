using Common.Core.Data.Sql;
using Common.Core.DependencyInjection;

namespace Infrastructure.Data.Sql
{
    [ServiceLocate(typeof(IPersistence))]
    public class Persistence : IPersistence
    {
        private readonly IMindBridgeCampDbContext _context;

        public Persistence(IMindBridgeCampDbContext context)
        {
            _context = context;
        }

        public void Complete()
        {
            _context.Save();
        }
    }
}

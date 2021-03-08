using Common.Core.Data.Sql;
using Common.Core.DependencyInjection;
using System.Threading.Tasks;

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

        public async Task<int> Complete()
        {
            return await _context.Save();
        }
    }
}

using System.Threading.Tasks;

namespace PDMAngular.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PdmDbContext _context;

        public UnitOfWork(PdmDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

using Microsoft.EntityFrameworkCore;

namespace PDMAngular.Persistence
{
    public class PdmDbContext : DbContext
    {
        public PdmDbContext(DbContextOptions<PdmDbContext> options) : base(options)
        {

        }
    }
}

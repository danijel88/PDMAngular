using Microsoft.EntityFrameworkCore;
using PDMAngular.Models;

namespace PDMAngular.Persistence
{
    public class PdmDbContext : DbContext
    {
        public DbSet<ItemType> ItemTypes { get; set; }
        public DbSet<MachineType> MachineTypes { get; set; }
        public DbSet<Item> Items { get; set; }

        public PdmDbContext(DbContextOptions<PdmDbContext> options) : base(options)
        {

        }
    }
}

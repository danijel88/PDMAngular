using Microsoft.EntityFrameworkCore;
using PDMAngular.Models;
using System.Threading.Tasks;

namespace PDMAngular.Persistence
{
    public class ItemRepository : IItemRepository
    {
        private readonly PdmDbContext _context;

        public ItemRepository(PdmDbContext context)
        {
            _context = context;
        }

        public async Task<Item> GetItem(int id, bool includeRelated = true)
        {
            if (!includeRelated)
                return await _context.Items.FindAsync(id);

            return await _context.Items
                .Include(i => i.ItemType)
                    .ThenInclude(it => it.Items)
                .Include(i => i.MachineType)
                    .ThenInclude(mt => mt.Items)
                .SingleOrDefaultAsync(i => i.Id == id);
        }

        public void Add(Item item)
        {
            _context.Items.Add(item);
        }

        public void Remove(Item item)
        {
            _context.Remove(item);
        }

    }
}

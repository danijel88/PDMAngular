using Microsoft.EntityFrameworkCore;
using PDMAngular.Core;
using PDMAngular.Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PDMAngular.Persistence
{
    public class ItemHistRepository : IItemHistRepository
    {
        private readonly PdmDbContext _context;

        public ItemHistRepository(PdmDbContext context)
        {
            _context = context;
        }

        public async Task<ItemHist> GetItemHistAsync(int id)
        {
            return await _context
                .ItemHists
                .SingleOrDefaultAsync(ih => ih.ItemId == id);
        }

        public void Add(ItemHist itemHist)
        {
            _context.ItemHists.Add(itemHist);
        }

        public void Remove(ItemHist itemHist)
        {
            _context.ItemHists.Remove(itemHist);
        }

        public async Task<IEnumerable<ItemHist>> GetItemHistListAsync(int id)
        {
            return await _context
                .ItemHists
                .Where(ih => ih.ItemId == id)
                .ToListAsync();
        }
    }
}

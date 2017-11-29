using Microsoft.EntityFrameworkCore;
using PDMAngular.Models;
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
    }
}

using Microsoft.EntityFrameworkCore;
using PDMAngular.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PDMAngular.Persistence
{
    public class ItemTypeRepository : IItemTypeRepository
    {
        private readonly PdmDbContext _context;

        public ItemTypeRepository(PdmDbContext context)
        {
            _context = context;
        }

        public async Task<ItemType> GetItemTypeAsync(int id)
        {
            return await _context
                .ItemTypes
                .FindAsync(id);
        }

        public async Task<IEnumerable<ItemType>> GetItemTypesAsync()
        {
            return await _context
                .ItemTypes
                .ToListAsync();
        }

        public void Add(ItemType itemType)
        {
            _context.ItemTypes.Add(itemType);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using PDMAngular.Core;
using PDMAngular.Core.Models;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IEnumerable<Item>> GetItems(ItemQuery queryObj)
        {
            //Client side filter - and need to be removed paramteres from method GetItems()
            //return await _context.Items
            //                .Include(i => i.ItemType)
            //        .ThenInclude(it => it.Items)
            //    .Include(i => i.MachineType)
            //        .ThenInclude(mt => mt.Items)
            //        .ToListAsync();

            //Server side filter
            var query = _context.Items
                            .Include(i => i.ItemType)
                    .ThenInclude(it => it.Items)
                .Include(i => i.MachineType)
                    .ThenInclude(mt => mt.Items)
                    .AsQueryable();


            if (queryObj.ItemTypeId.HasValue)
                query = query.Where(i => i.ItemType.Id == queryObj.ItemTypeId.Value);

            if (queryObj.MachineTypeId.HasValue)
                query = query.Where(i => i.MachineType.Id == queryObj.MachineTypeId.Value);

            if (queryObj.Status.HasValue)
                query = query.Where(i => i.Status == queryObj.Status);



            if (!string.IsNullOrEmpty(queryObj.InternalCode))
                query = query.Where(i => i.InternalCode.Contains(queryObj.InternalCode));





            return await query.ToListAsync();

        }


    }
}

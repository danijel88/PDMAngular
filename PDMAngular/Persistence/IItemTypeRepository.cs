using PDMAngular.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PDMAngular.Persistence
{
    public interface IItemTypeRepository
    {
        void Add(ItemType itemType);

        Task<ItemType> GetItemTypeAsync(int id);

        Task<IEnumerable<ItemType>> GetItemTypesAsync();
    }
}
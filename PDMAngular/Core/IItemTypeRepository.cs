using PDMAngular.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PDMAngular.Core
{
    public interface IItemTypeRepository
    {
        void Add(ItemType itemType);

        Task<ItemType> GetItemTypeAsync(int id);

        Task<IEnumerable<ItemType>> GetItemTypesAsync();
    }
}
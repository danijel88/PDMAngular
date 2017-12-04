using PDMAngular.Core.Models;
using System.Threading.Tasks;

namespace PDMAngular.Core
{
    public interface IItemRepository
    {
        Task<Item> GetItem(int id, bool includeRelated = true);

        void Add(Item item);

        void Remove(Item item);
    }
}
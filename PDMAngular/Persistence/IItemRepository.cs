using PDMAngular.Models;
using System.Threading.Tasks;

namespace PDMAngular.Persistence
{
    public interface IItemRepository
    {
        Task<Item> GetItem(int id, bool includeRelated = true);

        void Add(Item item);

        void Remove(Item item);
    }
}
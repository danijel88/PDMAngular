using PDMAngular.Models;
using System.Threading.Tasks;

namespace PDMAngular.Persistence
{
    public interface IItemHistRepository
    {
        Task<ItemHist> GetItemHistAsync(int id);

        void Add(ItemHist itemHist);

        void Remove(ItemHist itemHist);
    }
}
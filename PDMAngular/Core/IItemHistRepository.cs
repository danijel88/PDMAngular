using PDMAngular.Core.Models;
using System.Threading.Tasks;

namespace PDMAngular.Core
{
    public interface IItemHistRepository
    {
        Task<ItemHist> GetItemHistAsync(int id);

        void Add(ItemHist itemHist);

        void Remove(ItemHist itemHist);
    }
}
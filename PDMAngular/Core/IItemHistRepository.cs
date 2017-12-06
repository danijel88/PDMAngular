using PDMAngular.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PDMAngular.Core
{
    public interface IItemHistRepository
    {
        Task<ItemHist> GetItemHistAsync(int id);
        Task<IEnumerable<ItemHist>> GetItemHistListAsync(int id);

        void Add(ItemHist itemHist);

        void Remove(ItemHist itemHist);
    }
}
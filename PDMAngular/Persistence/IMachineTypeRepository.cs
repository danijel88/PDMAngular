using PDMAngular.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PDMAngular.Persistence
{
    public interface IMachineTypeRepository
    {
        void Add(MachineType itemType);
        Task<MachineType> GetMachineTypeAsync(int id);
        Task<IEnumerable<MachineType>> GetMachineTypesAsync();
    }
}
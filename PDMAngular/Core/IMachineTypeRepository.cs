using PDMAngular.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PDMAngular.Core
{
    public interface IMachineTypeRepository
    {
        void Add(MachineType itemType);
        Task<MachineType> GetMachineTypeAsync(int id);
        Task<IEnumerable<MachineType>> GetMachineTypesAsync();
    }
}
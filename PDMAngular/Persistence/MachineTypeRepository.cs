using Microsoft.EntityFrameworkCore;
using PDMAngular.Core;
using PDMAngular.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PDMAngular.Persistence
{
    public class MachineTypeRepository : IMachineTypeRepository
    {
        private readonly PdmDbContext _context;

        public MachineTypeRepository(PdmDbContext context)
        {
            _context = context;
        }

        public async Task<MachineType> GetMachineTypeAsync(int id)
        {
            return await _context
                .MachineTypes
                .FindAsync(id);
        }

        public async Task<IEnumerable<MachineType>> GetMachineTypesAsync()
        {
            return await _context
                .MachineTypes
                .ToListAsync();
        }

        public void Add(MachineType itemType)
        {
            _context.MachineTypes.Add(itemType);
        }
    }
}

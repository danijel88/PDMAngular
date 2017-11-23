using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PDMAngular.Controllers.Resources;
using PDMAngular.Models;
using PDMAngular.Persistence;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PDMAngular.Controllers
{
    [Route("/api/machinetypes")]
    public class MachineTypesController : Controller
    {
        private readonly PdmDbContext _context;
        private readonly IMapper _mapper;

        public MachineTypesController(PdmDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<MachineTypeResource>> GetMachineTypes()
        {
            var machineTypes = await _context.MachineTypes.ToListAsync();

            return _mapper.Map<List<MachineType>, List<MachineTypeResource>>(machineTypes);
        }
    }
}

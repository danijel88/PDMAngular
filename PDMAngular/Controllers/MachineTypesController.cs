using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PDMAngular.Controllers.Resources;
using PDMAngular.Models;
using PDMAngular.Persistence;
using System;
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

        [HttpPost]
        public async Task<IActionResult> CreateMachineType([FromBody] MachineTypeResource machineTypeResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var machineType = _mapper.Map<MachineTypeResource, MachineType>(machineTypeResource);

            machineType.CreateDate = DateTime.Now;

            _context.MachineTypes.Add(machineType);
            await _context.SaveChangesAsync();

            var result = _mapper.Map<MachineType, MachineTypeResource>(machineType);
            return Ok(result);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCreateMachineType(int id, [FromBody] MachineTypeResource machineTypeResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var machineType = await _context.MachineTypes.FindAsync(id);
            _mapper.Map<MachineTypeResource, MachineType>(machineTypeResource);

            machineType.UpdateDate = DateTime.Now;

            await _context.SaveChangesAsync();

            var result = _mapper.Map<MachineType, MachineTypeResource>(machineType);
            return Ok(result);
        }


        [HttpGet]
        public async Task<IEnumerable<MachineTypeResource>> GetMachineTypes()
        {
            var machineTypes = await _context.MachineTypes.ToListAsync();

            return _mapper.Map<List<MachineType>, List<MachineTypeResource>>(machineTypes);
        }
    }
}

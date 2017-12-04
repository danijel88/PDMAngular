using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PDMAngular.Controllers.Resources;
using PDMAngular.Core;
using PDMAngular.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PDMAngular.Controllers
{
    [Route("/api/machinetypes")]
    public class MachineTypesController : Controller
    {

        private readonly IMapper _mapper;
        private readonly IMachineTypeRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public MachineTypesController(IUnitOfWork unitOfWork,
            IMapper mapper,
            IMachineTypeRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMachineType([FromBody] MachineTypeResource machineTypeResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var machineType = _mapper.Map<MachineTypeResource, MachineType>(machineTypeResource);

            machineType.CreateDate = DateTime.Now;

            _repository.Add(machineType);
            await _unitOfWork.CompleteAsync();

            var result = _mapper.Map<MachineType, MachineTypeResource>(machineType);
            return Ok(result);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCreateMachineType(int id, [FromBody] MachineTypeResource machineTypeResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var machineType = await _repository.GetMachineTypeAsync(id);
            _mapper.Map<MachineTypeResource, MachineType>(machineTypeResource);

            machineType.UpdateDate = DateTime.Now;

            await _unitOfWork.CompleteAsync();

            var result = _mapper.Map<MachineType, MachineTypeResource>(machineType);
            return Ok(result);
        }


        [HttpGet]
        public async Task<IEnumerable<MachineTypeResource>> GetMachineTypes()
        {
            var machineTypes = await _repository.GetMachineTypesAsync();

            return _mapper.Map<IEnumerable<MachineType>, IEnumerable<MachineTypeResource>>(machineTypes);
        }
    }
}

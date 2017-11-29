using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PDMAngular.Controllers.Resources;
using PDMAngular.Models;
using PDMAngular.Persistence;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PDMAngular.Controllers
{
    [Route("/api/itemtypes")]
    public class ItemTypesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IItemTypeRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public ItemTypesController(
            IMapper mapper,
            IItemTypeRepository repository,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> CreateItemType([FromBody] KeyValuePairResource itemTypeResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var itemType = _mapper.Map<KeyValuePairResource, ItemType>(itemTypeResource);
            itemType.CreateDate = DateTime.Now;

            _repository.Add(itemType);
            await _unitOfWork.CompleteAsync();

            var result = _mapper.Map<ItemType, KeyValuePairResource>(itemType);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItemType(int id, [FromBody] KeyValuePairResource itemTypeResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var itemType = await _repository.GetItemTypeAsync(id);
            _mapper.Map<KeyValuePairResource, ItemType>(itemTypeResource);
            itemType.UpdateDate = DateTime.Now;

            await _unitOfWork.CompleteAsync();

            var result = _mapper.Map<ItemType, KeyValuePairResource>(itemType);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IEnumerable<KeyValuePairResource>> GetItemTypes()
        {
            var itemTypes = await _repository.GetItemTypesAsync();
            return _mapper.Map<IEnumerable<ItemType>, IEnumerable<KeyValuePairResource>>(itemTypes);
        }
    }
}

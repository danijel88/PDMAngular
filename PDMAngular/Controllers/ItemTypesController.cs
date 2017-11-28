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
    [Route("/api/itemtypes")]
    public class ItemTypesController : Controller
    {
        private readonly PdmDbContext _context;
        private readonly IMapper _mapper;

        public ItemTypesController(PdmDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateItemType([FromBody] ItemTypeResource itemTypeResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var itemType = _mapper.Map<ItemTypeResource, ItemType>(itemTypeResource);
            itemType.CreateDate = DateTime.Now;

            _context.ItemTypes.Add(itemType);
            await _context.SaveChangesAsync();

            var result = _mapper.Map<ItemType, ItemTypeResource>(itemType);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItemType(int id, [FromBody] ItemTypeResource itemTypeResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var itemType = await _context.ItemTypes.FindAsync(id);
            _mapper.Map<ItemTypeResource, ItemType>(itemTypeResource);
            itemType.UpdateDate = DateTime.Now;

            await _context.SaveChangesAsync();

            var result = _mapper.Map<ItemType, ItemTypeResource>(itemType);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IEnumerable<ItemTypeResource>> GetItemTypes()
        {
            var itemTypes = await _context.ItemTypes.ToListAsync();
            return _mapper.Map<List<ItemType>, List<ItemTypeResource>>(itemTypes);
        }
    }
}

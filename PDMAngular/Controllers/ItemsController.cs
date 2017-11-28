using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PDMAngular.Controllers.Resources;
using PDMAngular.Models;
using PDMAngular.Persistence;
using System;
using System.Threading.Tasks;

namespace PDMAngular.Controllers
{
    [Route("/api/items")]
    public class ItemsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly PdmDbContext _context;

        public ItemsController(IMapper mapper, PdmDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateItem([FromBody]ItemResource itemResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var item = _mapper.Map<ItemResource, Item>(itemResource);
            item.CreateDate = DateTime.Now;

            _context.Items.Add(item);
            await _context.SaveChangesAsync();

            var result = _mapper.Map<Item, ItemResource>(item);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItem(int id, [FromBody]ItemResource itemResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var item = await _context.Items.FindAsync(id);
            _mapper.Map<ItemResource, Item>(itemResource, item);

            item.UpdateDate = DateTime.Now;

            await _context.SaveChangesAsync();

            var result = _mapper.Map<Item, ItemResource>(item);

            return Ok(result);
        }

    }
}

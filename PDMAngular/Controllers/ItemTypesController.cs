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

        public async Task<IEnumerable<ItemTypeResource>> GetItemTypes()
        {
            var itemTypes = await _context.ItemTypes.ToListAsync();
            return _mapper.Map<List<ItemType>, List<ItemTypeResource>>(itemTypes);
        }
    }
}

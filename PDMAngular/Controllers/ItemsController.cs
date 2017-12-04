using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PDMAngular.Controllers.Resources;
using PDMAngular.Core;
using PDMAngular.Core.Models;
using System;
using System.Threading.Tasks;

namespace PDMAngular.Controllers
{
    [Route("/api/items")]
    public class ItemsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IItemRepository _repository;
        private readonly IItemHistRepository _itemHistRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ItemsController(IMapper mapper,
            IItemRepository repository,
            IItemHistRepository itemHistRepository,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _repository = repository;
            _itemHistRepository = itemHistRepository;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> CreateItem([FromBody]SaveItemResource itemResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var item = _mapper.Map<SaveItemResource, Item>(itemResource);
            item.CreateDate = DateTime.Now;

            _repository.Add(item);
            await _unitOfWork.CompleteAsync();

            item = await _repository.GetItem(item.Id);

            var result = _mapper.Map<Item, ItemResource>(item);

            await CreateItemHist(result.Id, itemResource);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItem(int id, [FromBody]SaveItemResource itemResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var item = await _repository.GetItem(id);

            if (item == null)
                return NotFound();

            _mapper.Map<SaveItemResource, Item>(itemResource, item);

            item.UpdateDate = DateTime.Now;

            await _unitOfWork.CompleteAsync();



            var result = _mapper.Map<Item, ItemResource>(item);

            await CreateItemHist(id, itemResource);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {

            //Removing item history
            var itemHists = await _itemHistRepository.GetItemHistAsync(id);
            if (itemHists != null)
            {
                _itemHistRepository.Remove(itemHists);
                await _unitOfWork.CompleteAsync();
            }

            //Remove Item
            var item = await _repository.GetItem(id, includeRelated: false);
            if (item == null)
                return NotFound();

            _repository.Remove(item);
            await _unitOfWork.CompleteAsync();

            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem(int id)
        {
            var item = await _repository.GetItem(id);

            if (item == null)
                return NotFound();

            var itemResource = _mapper.Map<Item, ItemResource>(item);
            return Ok(itemResource);
        }

        private async Task<bool> CreateItemHist(int id, [FromBody] SaveItemResource itemResource)
        {
            var itemHist = _mapper.Map<SaveItemResource, ItemHist>(itemResource);

            itemHist.ItemId = id;

            _itemHistRepository.Add(itemHist);

            await _unitOfWork.CompleteAsync();

            return true;
        }



    }
}

using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PDMAngular.Controllers.Resources;
using PDMAngular.Core;
using PDMAngular.Core.Models;
using System;
using System.IO;
using System.Threading.Tasks;

namespace PDMAngular.Controllers
{
    [Route("/api/items/{itemId}/photos")]
    public class PhotosController : Controller
    {
        private readonly IHostingEnvironment _host;
        private readonly IItemRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly PhotoSettings _photoSettings;

        public PhotosController(IHostingEnvironment host,
            IItemRepository repository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IOptionsSnapshot<PhotoSettings> options)
        {
            _host = host;
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _photoSettings = options.Value;
        }

        [HttpPost]
        public async Task<IActionResult> Upload(int itemId, IFormFile file)
        {

            var item = await _repository.GetItem(itemId, false);

            if (item == null)
                return NotFound();

            if (file == null)
                return BadRequest("Null file");

            if (file.Length == 0)
                return BadRequest("Empty file");

            if (file.Length > _photoSettings.MaxBytes)
                return BadRequest("Maximum file size exceeded");

            if (!_photoSettings.IsSupported(file.FileName))
                return BadRequest("Invalid file type");

            var uploadsFolderPath = Path.Combine(_host.WebRootPath, "uploads");

            if (!Directory.Exists(uploadsFolderPath))
                Directory.CreateDirectory(uploadsFolderPath);


            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(uploadsFolderPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var photo = new Photo { FileName = fileName };
            item.Photos.Add(photo);

            await _unitOfWork.CompleteAsync();

            return Ok(_mapper.Map<Photo, PhotoResource>(photo));
        }
    }
}

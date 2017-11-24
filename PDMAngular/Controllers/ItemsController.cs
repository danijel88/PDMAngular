using Microsoft.AspNetCore.Mvc;
using PDMAngular.Models;

namespace PDMAngular.Controllers
{
    [Route("/api/items")]
    public class ItemsController : Controller
    {
        [HttpPost]
        public IActionResult CreateItem([FromBody]Item item)
        {
            return Ok(item);
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineBooks.Model;
using OnlineBooks.Service.Contracts;
using System;
using System.Threading.Tasks;

namespace OnlineBooks.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CatalogueController : ControllerBase
    {
        private ICatalogueService _catalogueService;

        public CatalogueController(ICatalogueService catalogueService)
        {
            _catalogueService = catalogueService;
        }

        [AllowAnonymous]
        [HttpGet()]
        public async Task<IActionResult> GetCatalogues()
        {
            return Ok(await _catalogueService.GetCatalogue());
        }

        [HttpPost()]
        public async Task<IActionResult> CreateCatalogue([FromBody] CatalogueModel request)
        {
            return Ok(await _catalogueService.CreateCatalogue(request));
        }


        [HttpPut()]
        public async Task<IActionResult> UpdateCatalogue([FromBody] CatalogueModel request)
        {
            return Ok(await _catalogueService.UpdateCatalogue(request));
        }
         
        [HttpDelete()]
        public async Task<IActionResult> DeleteCatalogue(Guid catalogueId)
        {
            return Ok(await _catalogueService.DeleteCatalogue(catalogueId));
        }
    }
}

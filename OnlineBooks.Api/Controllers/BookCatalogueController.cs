using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineBooks.Model;
using OnlineBooks.Service.Contracts;
using System;
using System.Threading.Tasks;

namespace OnlineBooks.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BookCatalogueController : ControllerBase
    {
        private IBookCatalogueService _bookCatalogueService;
        public BookCatalogueController(IBookCatalogueService bookCatalogueService)
        {
            _bookCatalogueService = bookCatalogueService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetBookCatalogues()
        {
            return Ok(await _bookCatalogueService.GetBookCatalogues());
        }

        [AllowAnonymous]
        [HttpGet("{catalogueId}")]
        public async Task<IActionResult> GetBookCatalogues(Guid catalogueId)
        {
            return Ok(await _bookCatalogueService.GetBooksByCatalogues(catalogueId));
        }

        [HttpPost()]
        public async Task<IActionResult> CreateBookCatalogue([FromBody] BookCatalogueModel request)
        {
            return Ok(await _bookCatalogueService.CreateBookCatalogue(request));
        }


        [HttpPut()]
        public async Task<IActionResult> UpdateBookCatalogue([FromBody] BookCatalogueModel request)
        {
            return Ok(await _bookCatalogueService.UpdateBookCatalogue(request));
        }

        [HttpDelete()]
        public async Task<IActionResult> DeleteBookCatalogue(Guid bookId)
        {
            return Ok(await _bookCatalogueService.DeleteBookCatalogue(bookId));
        }
    }
}

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
    public class BookController : ControllerBase
    {
        private IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [AllowAnonymous]
        [HttpGet()]
        public async Task<IActionResult> GetBooks()
        {
            return Ok(await _bookService.GetBooks());
        }

        [HttpPost()]
        public async Task<IActionResult> CreateBook([FromBody] BookModel request)
        {
            return Ok(await _bookService.CreateBook(request));
        }


        [HttpPut()]
        public async Task<IActionResult> UpdateBook([FromBody] BookModel request)
        {
            return Ok(await _bookService.UpdateBook(request));
        }

        [HttpDelete()]
        public async Task<IActionResult> DeleteBook(Guid bookId)
        {
            return Ok(await _bookService.DeleteBook(bookId));
        }
    }
}

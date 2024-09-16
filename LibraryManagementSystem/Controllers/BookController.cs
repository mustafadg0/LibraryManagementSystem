using LibraryManagementSystem.Business;
using LibraryManagementSystem.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var result = await _bookService.GetBooksAsync();
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook(int id)
        {
            var result = await _bookService.GetBookAsync(id);
            if (!result.Success)
            {
                return NotFound(result.Message);
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody] Book book)
        {
            var result = await _bookService.AddBookAsync(book);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] Book book)
        {
            book.Id = id;
            var result = await _bookService.UpdateBookAsync(book);
            if (!result.Success)
            {
                return NotFound(result.Message);
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var result = await _bookService.DeleteBookAsync(id);
            if (!result.Success)
            {
                return NotFound(result.Message);
            }

            return Ok(result);
        }
    }
}

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
        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await _bookService.GetBooksAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await _bookService.GetBookAsync(id);
            if (book == null)
                return NotFound();
            return book;
        }

        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody] Book book)
        {
            await _bookService.AddBookAsync(book);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] Book book)
        {
            var existingBook = await _bookService.GetBookAsync(id);
            if (existingBook == null)
                return NotFound();

            book.Id = id;
            await _bookService.UpdateBookAsync(book);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _bookService.GetBookAsync(id);
            if (book == null)
                return NotFound();

            await _bookService.DeleteBookAsync(id);
            return Ok();
        }
    }
}

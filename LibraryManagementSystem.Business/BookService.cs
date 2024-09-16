using LibraryManagementSystem.Common;
using LibraryManagementSystem.Data;
using LibraryManagementSystem.Entities;
using LibraryManagementSystem.Messaging;

namespace LibraryManagementSystem.Business
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        // Fetches all books from the repository
        public async Task<Result<IEnumerable<Book>>> GetBooksAsync()
        {
            try
            {
                var books = await _bookRepository.GetAllBooksAsync();
                return Result<IEnumerable<Book>>.SuccessResult(books, "Books retrieved successfully.");
            }
            catch (Exception ex)
            {
                return Result<IEnumerable<Book>>.ErrorResult($"An error occurred while retrieving books: {ex.Message}");
            }
        }

        // Fetches a specific book by ID
        public async Task<Result<Book>> GetBookAsync(int id)
        {
            try
            {
                var book = await _bookRepository.GetBookByIdAsync(id);
                if (book == null)
                {
                    return Result<Book>.ErrorResult("Book not found.");
                }
                return Result<Book>.SuccessResult(book, "Book retrieved successfully.");
            }
            catch (Exception ex)
            {
                return Result<Book>.ErrorResult($"An error occurred while retrieving the book: {ex.Message}");
            }
        }

        // Adds a new book to the repository
        public async Task<Result<Book>> AddBookAsync(Book book)
        {
            try
            {
                await _bookRepository.AddBookAsync(book);
                var rabbitMQPublisher = new RabbitMQPublisher();
                rabbitMQPublisher.PublishMessage($"New book added: {book.Title}");
                return Result<Book>.SuccessResult(book, "Book added successfully.");
            }
            catch (Exception ex)
            {
                return Result<Book>.ErrorResult($"An error occurred while adding the book: {ex.Message}");
            }
        }

        // Updates an existing book
        public async Task<Result<Book>> UpdateBookAsync(Book book)
        {
            try
            {
                var existingBook = await _bookRepository.GetBookByIdAsync(book.Id);
                if (existingBook == null)
                {
                    return Result<Book>.ErrorResult("Book to update not found.");
                }

                await _bookRepository.UpdateBookAsync(book);
                return Result<Book>.SuccessResult(book, "Book updated successfully.");
            }
            catch (Exception ex)
            {
                return Result<Book>.ErrorResult($"An error occurred while updating the book: {ex.Message}");
            }
        }

        // Deletes a book by ID
        public async Task<Result<string>> DeleteBookAsync(int id)
        {
            try
            {
                var book = await _bookRepository.GetBookByIdAsync(id);
                if (book == null)
                {
                    return Result<string>.ErrorResult("Book to delete not found.");
                }

                await _bookRepository.DeleteBookAsync(id);
                return Result<string>.SuccessResult(null, "Book deleted successfully.");
            }
            catch (Exception ex)
            {
                return Result<string>.ErrorResult($"An error occurred while deleting the book: {ex.Message}");
            }
        }
    }
}

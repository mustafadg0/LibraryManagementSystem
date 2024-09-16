using LibraryManagementSystem.Common;
using LibraryManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Business
{
    public interface IBookService
    {
        Task<Result<IEnumerable<Book>>> GetBooksAsync();
        Task<Result<Book>> GetBookAsync(int id);
        Task<Result<Book>> AddBookAsync(Book book);
        Task<Result<Book>> UpdateBookAsync(Book book);
        Task<Result<string>> DeleteBookAsync(int id);
    }
}

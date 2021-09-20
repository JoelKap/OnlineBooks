using OnlineBooks.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineBooks.Service.Contracts
{
    public interface IBookService
    {
        Task<IEnumerable<BookModel>> GetBooks();
        Task<bool> CreateBook(BookModel request);
        Task<bool> UpdateBook(BookModel request);
        Task<bool> DeleteBook(Guid bookId);
    }
}

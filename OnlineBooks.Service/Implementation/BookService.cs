using OnlineBooks.DataAccess.Contracts;
using OnlineBooks.Model;
using OnlineBooks.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBooks.Service.Implementation
{
   public class BookService: IBookService
    {
        private IBookDataAccess _bookDataService;
        public BookService(IBookDataAccess bookDataService)
        {
            _bookDataService = bookDataService;
        }

        public async Task<bool> CreateBook(BookModel request)
        {
            return await _bookDataService.CreateBook(request);
        }

        public async Task<bool> DeleteBook(Guid bookId)
        {
            return await _bookDataService.DeleteBook(bookId);
        }

        public async Task<IEnumerable<BookModel>> GetBookByCatalogueId(Guid subscriptionId, Guid userId)
        {
            return await _bookDataService.GetBookByCatalogueId(subscriptionId, userId);
        }

        public async Task<IEnumerable<BookModel>> GetBooks()
        {
            return await _bookDataService.GetBooks();
        }

        public async Task<bool> UpdateBook(BookModel request)
        {
            return await _bookDataService.UpdateBook(request);
        }
    }
}

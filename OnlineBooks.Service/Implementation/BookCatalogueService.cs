using OnlineBooks.DataAccess.Contracts;
using OnlineBooks.Model;
using OnlineBooks.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineBooks.Service.Implementation
{
    public class BookCatalogueService: IBookCatalogueService
    {
        private IBookCatalogueDataAccess _bookCatalogueBookAccess;
        public BookCatalogueService(IBookCatalogueDataAccess bookCatalogueDataAccess)
        {
            _bookCatalogueBookAccess = bookCatalogueDataAccess;
        }

        public async Task<bool> CreateBookCatalogue(BookCatalogueModel request)
        {
            return await _bookCatalogueBookAccess.CreateBookCatalogue(request);
        }

        public async Task<bool> DeleteBookCatalogue(Guid bookCatalogueId)
        {
            return await _bookCatalogueBookAccess.DeleteBookCatalogue(bookCatalogueId);
        }

        public Task<IEnumerable<BookCatalogueModel>> GetBookCatalogues()
        {
            return _bookCatalogueBookAccess.GetBookCatalogues();
        }

        public async Task<bool> UpdateBookCatalogue(BookCatalogueModel request)
        {
            return await _bookCatalogueBookAccess.UpdateBookCatalogue(request);
        }
    }
}

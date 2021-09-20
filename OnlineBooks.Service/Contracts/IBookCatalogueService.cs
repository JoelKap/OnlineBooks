using OnlineBooks.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineBooks.Service.Contracts
{
    public interface IBookCatalogueService
    {
        Task<IEnumerable<BookCatalogueModel>> GetBookCatalogues();
        Task<bool> CreateBookCatalogue(BookCatalogueModel request);
        Task<bool> UpdateBookCatalogue(BookCatalogueModel request);
        Task<bool> DeleteBookCatalogue(Guid bookCatalogueId);
    }
}

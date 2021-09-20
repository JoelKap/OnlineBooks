using AutoMapper;
using OnlineBooks.DataAccess.Contracts;
using OnlineBooks.DataAccess.DTO;
using OnlineBooks.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBooks.DataAccess.Implementations
{
   public class BookCatalogueDataAccess: IBookCatalogueDataAccess
    {
        private readonly OnlineBooksContext _onlineBooksContext;
        private readonly IMapper _mapper;
        public BookCatalogueDataAccess(OnlineBooksContext onlineBooksContext)
        {
            _onlineBooksContext = onlineBooksContext;
            _mapper = Mappings.MappingProfile.MapperConfiguration();
        }

        public async Task<bool> CreateBookCatalogue(BookCatalogueModel request)
        {
            var bookCatDto = _mapper.Map<BookCatalogueModel, BookCatalogue>(request);
            _onlineBooksContext.BookCatalogues.Add(bookCatDto);
            var response = _onlineBooksContext.SaveChanges();
            if (response == 1)
                return true;

            return false;
        }

        public async Task<bool> DeleteBookCatalogue(Guid bookCatalogueId)
        {
            BookCatalogue bookCatelogue = _onlineBooksContext.BookCatalogues.FirstOrDefault(x => x.BookId == bookCatalogueId);
            if (bookCatelogue is null)
                return false;
            bookCatelogue.IsDeleted = true;
            var response = _onlineBooksContext.SaveChanges();
            if (response == 1)
                return true;

            return false;
        }

        public async Task<IEnumerable<BookCatalogueModel>> GetBookCatalogues()
        {
            var bookCatalogues = new List<BookCatalogueModel>();
            var bookCatsDto = _onlineBooksContext.BookCatalogues.Where(x => x.IsDeleted == false).ToList();
            for (int i = 0; i < bookCatsDto.Count; i++)
            {
                var bookCat = _mapper.Map<BookCatalogue, BookCatalogueModel>(bookCatsDto[i]);
                bookCatalogues.Add(bookCat);
            }
            return bookCatalogues;
        }

        public async Task<bool> UpdateBookCatalogue(BookCatalogueModel request)
        {
            BookCatalogue bookCatelogueDto = _onlineBooksContext.BookCatalogues.FirstOrDefault(x => x.BookId == request.BookCatalogueId);
            _mapper.Map<BookCatalogueModel, BookCatalogue>(request, bookCatelogueDto);
            var response = _onlineBooksContext.SaveChanges();
            if (response == 1)
                return true;

            return false;
        }
    }
}

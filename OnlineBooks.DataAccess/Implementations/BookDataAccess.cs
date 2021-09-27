using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineBooks.DataAccess.Contracts;
using OnlineBooks.DataAccess.DTO;
using OnlineBooks.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBooks.DataAccess.Implementations
{
    public class BookDataAccess : IBookDataAccess
    {
        private readonly OnlineBooksContext _onlineBooksContext;
        private readonly IMapper _mapper;
        public BookDataAccess(OnlineBooksContext onlineBooksContext)
        {
            _onlineBooksContext = onlineBooksContext;
            _mapper = Mappings.MappingProfile.MapperConfiguration();
        }
        public async Task<IEnumerable<BookModel>> GetBooks()
        {
            var books = new List<BookModel>();
            var booksDto = _onlineBooksContext.Books.Where(x => x.IsDeleted == false).ToList();
            for (int i = 0; i < booksDto.Count; i++)
            {
                var book = _mapper.Map<Book, BookModel>(booksDto[i]);
                books.Add(book);
            }
            return books;
        }

        public async Task<bool> CreateBook(BookModel request)
        {
            var bookDto = _mapper.Map<BookModel, Book>(request);
            _onlineBooksContext.Books.Add(bookDto);
            var response = _onlineBooksContext.SaveChanges();
            if (response == 1)
                return true;

            return false;
        }
        public async Task<bool> UpdateBook(BookModel request)
        {
            Book bookDto = _onlineBooksContext.Books.FirstOrDefault(x => x.BookId == request.BookId);
            _mapper.Map<BookModel, Book>(request, bookDto);
            var response = _onlineBooksContext.SaveChanges();
            if (response == 1)
                return true;

            return false;
        }
        public async Task<bool> DeleteBook(Guid bookId)
        {
            Book bookDto = _onlineBooksContext.Books.FirstOrDefault(x => x.BookId == bookId);
            if (bookDto is null)
                return false;
            bookDto.IsDeleted = true;
            var response = _onlineBooksContext.SaveChanges();
            if (response == 1)
                return true;

            return false;
        }

        public async Task<IEnumerable<BookModel>> GetBookByCatalogueId(Guid subscriptionId, Guid userId)
        {
            var list = new List<BookModel>();
            var bookIds = new List<Guid>();

            List<Subscription> subsDto = _onlineBooksContext.Subscriptions
                .Include(x=> x.Catalogue)
                .Include(x => x.Catalogue.BookCatalogues)
                .Include(x=> x.Unsubscribes.Where(x=> x.SubscriptionId == subscriptionId && x.UserId == userId && x.IsDeleted == false)).ToList()
                .Where(x => x.SubscriptionId == subscriptionId && x.UserId == userId && x.IsDeleted == false)
                .ToList();

            for (int i = 0; i < subsDto.Count; i++)
            {
                var unsubs = subsDto[i].Unsubscribes.ToList();
                for (int k = 0; k < unsubs.Count; k++)
                {
                    var bookDto = _onlineBooksContext.Books.FirstOrDefault(x => x.IsDeleted == false && x.BookId == unsubs[k].BookId);
                    var bookModel = _mapper.Map<Book, BookModel>(bookDto);
                    list.Add(bookModel);
                }
            }
            return list;
        }
    }
}

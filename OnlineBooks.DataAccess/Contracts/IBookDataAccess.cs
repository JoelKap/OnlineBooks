﻿using OnlineBooks.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineBooks.DataAccess.Contracts
{
    public interface IBookDataAccess
    {
        Task<IEnumerable<BookModel>> GetBooks();
        Task<IEnumerable<BookModel>> GetBookByCatalogueId(Guid subscriptionId, Guid userId);
        Task<bool> CreateBook(BookModel request);
        Task<bool> UpdateBook(BookModel request);
        Task<bool> DeleteBook(Guid bookId);
    }
}

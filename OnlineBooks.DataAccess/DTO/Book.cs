using System;
using System.Collections.Generic;

#nullable disable

namespace OnlineBooks.DataAccess.DTO
{
    public partial class Book
    {
        public Book()
        {
            BookCatalogues = new HashSet<BookCatalogue>();
            Unsubscribes = new HashSet<Unsubscribe>();
        }

        public Guid BookId { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<BookCatalogue> BookCatalogues { get; set; }
        public virtual ICollection<Unsubscribe> Unsubscribes { get; set; }
    }
}

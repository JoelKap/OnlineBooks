using System;

namespace OnlineBooks.Model
{
    public class BookModel
    {
        public Guid BookId { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public Decimal Price { get; set; } 
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; } 
    }
}

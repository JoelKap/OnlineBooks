using System;
using System.Collections.Generic;

namespace OnlineBooks.Model
{
    public class CatalogueModel 
    {
        public Guid CatalogueId { get; set; }
        public string Name { get; set; }
        public Decimal Price { get; set; }  
        public DateTime CreatedAt { get; set; } 
        public bool IsDeleted { get; set; } 
        public List<BookCatalogueModel> BookCatalogues { get; set; }
        public List<BookModel> Books { get; set; }
    }
}
 
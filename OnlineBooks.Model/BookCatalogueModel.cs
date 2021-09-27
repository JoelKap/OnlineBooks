using System;
using System.Collections.Generic;

namespace OnlineBooks.Model
{
   public class BookCatalogueModel
    {
        public Guid BookCatalogueId { get; set; }
        public Guid CatalogueId { get; set; }  
        public List<Guid> BookIds { get; set; } 
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public BookModel book { get; set; }
    } 
}

using System;
using System.Collections.Generic;

#nullable disable

namespace OnlineBooks.DataAccess.DTO
{
    public partial class BookCatalogue
    {
        public Guid BookCatalogueId { get; set; }
        public Guid CatalogueId { get; set; }
        public Guid BookId { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Book Book { get; set; }
        public virtual Catalogue Catalogue { get; set; }
    }
}

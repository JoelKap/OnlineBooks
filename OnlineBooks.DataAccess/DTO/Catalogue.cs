using System;
using System.Collections.Generic;

#nullable disable

namespace OnlineBooks.DataAccess.DTO
{
    public partial class Catalogue
    {
        public Catalogue()
        {
            BookCatalogues = new HashSet<BookCatalogue>();
            Subscriptions = new HashSet<Subscription>();
        }

        public Guid CatalogueId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<BookCatalogue> BookCatalogues { get; set; }
        public virtual ICollection<Subscription> Subscriptions { get; set; }
    }
}

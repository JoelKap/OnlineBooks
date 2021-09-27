using System;
using System.Collections.Generic;

namespace OnlineBooks.Model
{
    public class SubscriptionModel
    {
        public Guid SubscriptionId { get; set; }
        public Guid UserId { get; set; }
        public Guid CatalogueId { get; set; }
        public string Reference { get; set; }
        public List<CatalogueModel> Catalogs { get; set; }
        public CatalogueModel Catalogue { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; } 
    } 
}

  
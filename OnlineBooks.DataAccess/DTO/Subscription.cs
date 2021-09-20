using System;
using System.Collections.Generic;

#nullable disable

namespace OnlineBooks.DataAccess.DTO
{
    public partial class Subscription
    {
        public Subscription()
        {
            Unsubscribes = new HashSet<Unsubscribe>();
        }

        public Guid SubscriptionId { get; set; }
        public Guid UserId { get; set; }
        public Guid CatalogId { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public string Reference { get; set; }

        public virtual Catalogue Catalog { get; set; }
        public virtual OnlineUser User { get; set; }
        public virtual ICollection<Unsubscribe> Unsubscribes { get; set; }
    }
}

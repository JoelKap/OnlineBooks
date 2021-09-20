using System;
using System.Collections.Generic;

#nullable disable

namespace OnlineBooks.DataAccess.DTO
{
    public partial class Unsubscribe
    {
        public Guid UnsubscribeId { get; set; }
        public Guid SubscriptionId { get; set; }
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Book Book { get; set; }
        public virtual Subscription Subscription { get; set; }
        public virtual OnlineUser User { get; set; }
    }
}

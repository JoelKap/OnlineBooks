using System;
using System.Collections.Generic;

namespace OnlineBooks.Model
{
    public  class UnsubscribeModel
    {
        public Guid UnsubscribeId { get; set; }
        public Guid SubscriptionId { get; set; }
        public Guid UserId { get; set; } 
        public List<Guid> BookIds { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
 
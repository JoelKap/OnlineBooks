using System;
using System.Collections.Generic;

#nullable disable

namespace OnlineBooks.DataAccess.DTO
{
    public partial class OnlineUser
    {
        public OnlineUser()
        {
            Subscriptions = new HashSet<Subscription>();
            Unsubscribes = new HashSet<Unsubscribe>();
        }

        public Guid UserId { get; set; }
        public Guid OnlineUserTypeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }

        public virtual OnlineUserType OnlineUserType { get; set; }
        public virtual ICollection<Subscription> Subscriptions { get; set; }
        public virtual ICollection<Unsubscribe> Unsubscribes { get; set; }
    }
}

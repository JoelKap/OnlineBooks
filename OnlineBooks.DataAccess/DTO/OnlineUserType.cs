using System;
using System.Collections.Generic;

#nullable disable

namespace OnlineBooks.DataAccess.DTO
{
    public partial class OnlineUserType
    {
        public OnlineUserType()
        {
            OnlineUsers = new HashSet<OnlineUser>();
        }

        public Guid OnlineUserTypeId { get; set; }
        public string OnlineUserTypeName { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<OnlineUser> OnlineUsers { get; set; }
    }
}

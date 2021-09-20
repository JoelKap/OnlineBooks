using System;

namespace OnlineBooks.Model
{
    public class OnlineUserTypeModel
    {
        public Guid OnlineUserTypeId { get; set; }
        public string OnlineUserTypeName { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }

    }
}

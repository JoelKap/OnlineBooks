using System;
using System.Collections.Generic;

namespace OnlineBooks.Model
{
    public  class OnlineUserModel
    {
        public Guid UserId { get; set; }
        public Guid OnlineUserTypeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; } 
        public string Password { get; set; } 
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public OnlineUserTypeModel UserType { get; set; } = new OnlineUserTypeModel();
        public List<SubscriptionModel> Subscriptions { get; set; }
    }
}

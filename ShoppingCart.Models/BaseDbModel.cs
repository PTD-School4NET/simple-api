using System;

namespace ShoppingCart.Models
{
    public class BaseDbModel
    {
        public long Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset ModifiedAt { get; set; } 
        public bool IsDeleted { get; set; }
    }
}
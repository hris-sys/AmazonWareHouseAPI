using Data.Models.Interfaces;
using System;
using System.Collections.Generic;

namespace Data.Models.Models
{
    public class Cart : IAuditInfo, IIdable
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public DateTime? DeletedAt { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }

        public ICollection<ItemCart> ItemCarts { get; set; }
    }
}

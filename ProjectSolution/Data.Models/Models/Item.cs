using Data.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Models.Models
{
    public class Item : BaseModel, IAuditInfo
    {
        public Item()
        {
            this.OrderItems = new HashSet<OrderItem>();
            this.ItemCategories = new HashSet<ItemCategory>();
        }

        [Required(ErrorMessage = "The item price is required!")]
        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public DateTime? DeletedAt { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }

        public ICollection<ItemCategory> ItemCategories { get; set; }
    }
}

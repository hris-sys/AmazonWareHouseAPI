using Data.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Models.Models
{
    public class Item : BaseModel, IAuditInfo
    {
        [Required(ErrorMessage = "The item price is required!")]
        public decimal Price { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public DateTime? DeletedAt { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }

        public ICollection<ItemCategory> ItemCategories { get; set; }

        public ICollection<ItemCart> ItemCarts { get; set; }

        //add them to ctor
    }
}

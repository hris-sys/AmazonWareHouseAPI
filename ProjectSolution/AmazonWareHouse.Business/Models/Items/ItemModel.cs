using Data.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AmazonWareHouse.Business.Models.Items
{
    public class ItemModel : BaseModel
    {
        public ItemModel()
        {
            this.OrderItems = new HashSet<OrderItem>();
            this.ItemCategories = new HashSet<ItemCategory>();
        }

        [Required(ErrorMessage = "The item price is required!")]
        public decimal Price { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        public int Quantity { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public DateTime? DeletedAt { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }

        public ICollection<ItemCategory> ItemCategories { get; set; }
    }
}

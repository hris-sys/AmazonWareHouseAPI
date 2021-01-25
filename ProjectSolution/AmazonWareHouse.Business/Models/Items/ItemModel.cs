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
            this.OrderItemsIds = new List<string>();
            this.ItemCategoriesIds = new List<string>();
        }

        [Required(ErrorMessage = "The item price is required!")]
        public decimal Price { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        public int Quantity { get; set; }

        public bool isDeleted { get; set; }

        public DateTime CreatedAt { get; set; }

        public List<string> OrderItemsIds { get; set; }

        public List<string> ItemCategoriesIds { get; set; }

        public string CategoryName { get; set; }
    }
}

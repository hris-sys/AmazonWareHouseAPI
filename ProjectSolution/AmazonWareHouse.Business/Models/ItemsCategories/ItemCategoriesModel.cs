using Data.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmazonWareHouse.Business.Models.ItemsCategories
{
    public class ItemCategoriesModel : BaseModel
    {
        public Item Item { get; set; }
        public string ItemId { get; set; }

        public Category Category { get; set; }
        public string CategoryId { get; set; }
    }
}

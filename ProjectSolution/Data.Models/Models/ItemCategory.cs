using Data.Models.Interfaces;
using System;

namespace Data.Models.Models
{
    public class ItemCategory : IIdable
    {
        public ItemCategory(Item item, Category category)
        {
            this.Category = category;
            this.CategoryId = category.Id;
            this.Item = item;
            this.ItemId = item.Id;
        }

        public Guid Id { get; set; }

        public Item Item { get; set; }
        public Guid ItemId { get; set; }

        public Category Category { get; set; }
        public Guid CategoryId { get; set; }
    }
}

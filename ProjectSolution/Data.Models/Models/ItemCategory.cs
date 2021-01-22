using Data.Models.Interfaces;
using System;

namespace Data.Models.Models
{
    public class ItemCategory : IIdable
    {
        public ItemCategory()
        {
            this.Id = Guid.NewGuid().ToString().Substring(0, 7);
        }

        public string Id { get; set; }

        public Item Item { get; set; }
        public string ItemId { get; set; }

        public Category Category { get; set; }
        public string CategoryId { get; set; }
    }
}

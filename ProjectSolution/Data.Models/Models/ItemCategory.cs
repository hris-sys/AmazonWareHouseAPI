using Data.Models.Interfaces;

namespace Data.Models.Models
{
    public class ItemCategory : IIdable
    {
        public int Id { get; set; }

        public Item Item { get; set; }
        public int ItemId { get; set; }

        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}

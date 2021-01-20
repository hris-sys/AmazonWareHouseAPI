using Data.Models.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Models.Models
{
    public class Category : BaseModel
    {
        public Category()
        {
            this.ItemCategories = new HashSet<ItemCategory>();
        }
        public ICollection<ItemCategory> ItemCategories { get; set; }

    }
}

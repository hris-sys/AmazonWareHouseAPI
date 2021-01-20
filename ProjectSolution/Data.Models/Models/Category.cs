using Data.Models.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Models.Models
{
    public class Category : BaseModel
    {
        public ICollection<ItemCategory> ItemCategories { get; set; }

        //add to ctor
    }
}
